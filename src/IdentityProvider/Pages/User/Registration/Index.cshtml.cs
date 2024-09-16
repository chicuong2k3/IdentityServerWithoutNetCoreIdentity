using AspNetCoreHero.ToastNotification.Abstractions;
using Duende.IdentityServer;
using Duende.IdentityServer.Services;
using IdentityModel;
using IdentityProvider.Services;
using IdentityProvider.Services.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityProvider.Pages.User.Registration
{
    [AllowAnonymous]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        private readonly ILocalUserService _localUserService;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IMailService _mailService;
        private readonly INotyfService _notificationService;

        public IndexModel(
            ILocalUserService localUserService,
            IIdentityServerInteractionService interaction,
            IMailService mailService,
            INotyfService notificationService)
        {
            _localUserService = localUserService;
            _interaction = interaction;
            _mailService = mailService;
            _notificationService = notificationService;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        public IActionResult OnGet(string? returnUrl)
        {
            BuildModel(returnUrl);

            return Page();
        }

        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new Entites.User()
            {
                UserName = Input.UserName,
                Subject = Guid.NewGuid().ToString(),
                Email = Input.Email,
                Active = false
            };

            user.Claims.Add(new Entites.UserClaim()
            {
                Type = JwtClaimTypes.GivenName,
                Value = Input.GivenName
            });
            user.Claims.Add(new Entites.UserClaim()
            {
                Type = JwtClaimTypes.FamilyName,
                Value = Input.FamilyName
            });
            user.Claims.Add(new Entites.UserClaim()
            {
                Type = "country",
                Value = Input.Country
            });

            var addUserResult = _localUserService.AddUser(user, Input.Password);

            if (addUserResult == AddUserResults.DuplicateUserName)
            {
                ModelState.Remove("Input.UserName");
                ModelState.AddModelError("Input.UserName", "Tên đăng nhập đã tồn tại.");
                return Page();
            }
            else if (addUserResult == AddUserResults.DuplicateEmail)
            {
                ModelState.Remove("Input.Email");
                ModelState.AddModelError("Input.Email", "Email đã được sử dụng để đăng ký tài khoản.");
                return Page();
            }

            

            // create an activation link
            var activationLink = Url.PageLink("/User/Activation/Index",
                values: new { securityCode = user.SecurityCode }
            );

            Console.WriteLine(activationLink);

            var mailSent = await _mailService.SendMailAsync(new MailRequest()
            {
                ReceiverEmail = user.Email,
                ReceiverName = user.UserName,
                EmailSubject = "Kích hoạt tài khoản",
                EmailBody = $"Nhấn vào đây để kích hoạt tài khoản: <a href='{activationLink}'>Kích hoạt</a>"
            });

            if (!mailSent)
            {
                _notificationService.Error("Có lỗi xảy ra. Vui lòng thử lại sau.");
                return Redirect("~/");
            }

            await _localUserService.SaveChangesAsync();

            return Redirect("~/User/ActivationCodeSent");

        }

        private void BuildModel(string? returnUrl)
        {
            if (Input == null)
            {
                Input = new InputModel()
                {
                    ReturnUrl = returnUrl
                };
            }
            else
            {
                Input.ReturnUrl = returnUrl;
            }
        }
    }
}
