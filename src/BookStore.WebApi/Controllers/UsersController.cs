using BookStore.Application.Users.RegisterUser;
using BookStore.Application.Users.UpdateUser;
using BookStore.WebApi.Extensions;
using BookStore.WebApi.Requests.Users;

namespace BookStore.WebApi.Controllers
{
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISender sender;

        public UsersController(ISender sender)
        {
            this.sender = sender;
        }

        //[HttpPost("/users/addresses")]
        //public async Task<IActionResult> AddAddress([FromBody] AddAddressRequest request)
        //{
        //    var command = new AddAddressCommand(
        //        parsedUserId,
        //        request.Town,
        //        request.District,
        //        request.City,
        //        request.AddressLine
        //    );

        //    var result = await sender.Send(command);

        //    if (result.IsFailure)
        //    {
        //        return result.ProduceProblem();
        //    }

        //    return NoContent();
        //}

        //[HttpGet("/users/profile")]
        //public async Task<IActionResult> Get()
        //{
        //    var result = await sender.Send(new GetUserQuery(claims.GetUserId()));

        //    if (result.IsFailure)
        //    {
        //        return result.ProduceProblem();
        //    }

        //    return Ok(result.Value);
        //}

        //[HttpGet("/users/addresses")]
        //public async Task<IActionResult> ListAddresses()
        //{
        //    var query = new GetUserAddressesQuery(claims.GetUserId());
        //    var result = await sender.Send(query);

        //    if (result.IsFailure)
        //    {
        //        return result.ProduceProblem();
        //    }

        //    return Ok(result.Value);
        //}

        [HttpPost("/users/register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest request)
        {
            var command = new RegisterUserCommand(
                request.Email,
                request.Password,
                request.FirstName,
                request.LastName);

            var result = await sender.Send(command);

            if (result.IsFailure)
            {
                return result.ProduceProblem();
            }

            return Ok(result.Value);
        }

        //[HttpPut("/users/profile")]
        //public async Task<IActionResult> UpdateProfile([FromBody] UpdateUserProfileRequest request)
        //{
        //    var command = new UpdateUserProfileCommand(claims.GetUserId(), request.FirstName, request.LastName);

        //    var result = await sender.Send(command);

        //    if (result.IsFailure)
        //    {
        //        return result.ProduceProblem();
        //    }

        //    return NoContent();
        //}
    }
}
