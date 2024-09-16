using IdentityProvider.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityProvider.Pages.User.Activation
{
    [AllowAnonymous]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        private readonly ILocalUserService _localUserService;

        public IndexModel(ILocalUserService localUserService)
        {
            _localUserService = localUserService;
        }
        public async Task<IActionResult> OnGet(string securityCode)
        {
            if (await _localUserService.ActivateUserAsync(securityCode))
            {
                Input = new InputModel()
                {
                    Message = "Tài khoản của bạn đã được kích hoạt. <a href=\"/Account/Login\">Đăng nhập ngay</a>"
                };
            }
            else
            {
                Input = new InputModel()
                {
                    Message = "Tài khoản của bạn không thể được kích hoạt."
                };
            }

            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }
    }
}
