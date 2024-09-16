using BookStore.WebMvc.Books;
using BookStore.WebMvc.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BookStore.WebMvc.Controllers
{
    public class BookController : Controller
    {
        private readonly IBooksClient booksClient;
        private readonly ILogger<BookController> logger;

        public BookController(IBooksClient booksClient, ILogger<BookController> logger)
        {
            this.booksClient = booksClient;
            this.logger = logger;
        }

        [Authorize]
        public IActionResult Index()
        {
            LogIdentityInformation();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search([FromBody] DataTableRequest request)
        {
            int pageNumber = (int)Math.Ceiling((request.Start + 1) / (double) request.Length);
            var response = await booksClient.GetBooksAsync(pageNumber, request.Length, request.Search.Value);

            if (response.IsSuccessStatusCode)
            {

                if (response.Headers.TryGetValues("X-Pagination", out var paginationHeaders))
                {
                    var paginationMetadata = paginationHeaders.FirstOrDefault();
                    if (paginationMetadata != null)
                    {
                        var paginationInfo = JsonConvert.DeserializeObject<PaginationMetadata>(paginationMetadata);

                        if (paginationInfo is null)
                        {
                            return BadRequest();
                        }

                        var result = new
                        {
                            draw = request.Draw,
                            recordsTotal = paginationInfo.TotalCount,
                            recordsFiltered = response.Content.Count(),
                            data = response.Content
                        };

                        return Ok(result);

                    }
                }

            }

            return StatusCode((int)response.StatusCode, "Error occurred while fetching data.");
        }

        //[Authorize(Roles = "Admin")]
        //[Authorize(Policy = "UserCanCreateBook")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        //[Authorize(Policy = "UserCanCreateBook")]
        public async Task<IActionResult> Create(CreateBookModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await booksClient.CreateBookAsync(model);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized
                || response.StatusCode == HttpStatusCode.Forbidden)
                {
                    return RedirectToAction("AccessDenied", "Auth");
                }
            }

            return View(model);
        }

        public async Task LogIdentityInformation()
        {
            // get the saved identity token
            var identityToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.IdToken);

            // get the saved access token
            var accessToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.AccessToken);

            // get the refresh token
            var refreshToken = await HttpContext
                .GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

            var userClaimsStringBuilder = new StringBuilder();
            foreach (var claim in User.Claims)
            {
                userClaimsStringBuilder.AppendLine(
                    $"Claim type: {claim.Type} - Claim value: {claim.Value}");
            }

            // log token & claims
            logger.LogInformation($"Identity token & user claims: " +
                $"\n{identityToken} \n{userClaimsStringBuilder}");
            logger.LogInformation($"Access token: " +
                $"\n{accessToken}");
            logger.LogInformation($"Refresh token: " +
                $"\n{refreshToken}");
        }
    }
}
