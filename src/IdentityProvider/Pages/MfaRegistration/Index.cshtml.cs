using AspNetCoreHero.ToastNotification.Abstractions;
using IdentityModel;
using IdentityProvider.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace IdentityProvider.Pages.MfaRegistration
{
    [SecurityHeaders]
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILocalUserService _localUserService;
        private readonly INotyfService _notifyService;
        private readonly char[] charAndNumberArray =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        public IndexModel(ILocalUserService localUserService, INotyfService notifyService)
        {
            _localUserService = localUserService;
            _notifyService = notifyService;
        }

        public ViewModel View { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public async Task OnGet()
        {
            var token = RandomNumberGenerator.GetBytes(64);
            var secretStringBuilder = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                var random = BitConverter.ToUInt32(token, i * 4);

                secretStringBuilder.Append(charAndNumberArray[random % charAndNumberArray.Length]);
            }

            var secret = secretStringBuilder.ToString();

            var subject = User.FindFirst(JwtClaimTypes.Subject)?.Value ?? string.Empty;
            var user = await _localUserService.GetUserBySubjectAsync(subject);

            var appName = "Book Store";
            var keyUri = $"otpauth://totp/{WebUtility.UrlEncode(appName)}:{WebUtility.UrlEncode(user!.Email)}?secret={secret}&issuer={WebUtility.UrlEncode(appName)}";

            View = new ViewModel
            {
                KeyUri = keyUri
            };

            Input = new InputModel
            {
                Secret = secret
            };

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                _notifyService.Error("Đăng ký MFA thất bại.");
                return Page();
            }

            var subject = User.FindFirst(JwtClaimTypes.Subject)?.Value;

            if (await _localUserService.AddUserSecret(subject, "TOTP", Input.Secret))
            {
                await _localUserService.SaveChangesAsync();
                _notifyService.Success("Đăng ký MFA thành công.");
                return Redirect("~/");
            }
            else
            {
                throw new Exception("MFA registration error.");
            }

        }
    }
}
