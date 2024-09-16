using AspNetCoreHero.ToastNotification.Abstractions;
using IdentityProvider.Services;
using IdentityProvider.Services.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IdentityProvider.Pages.User.ForgotPassword
{
    [AllowAnonymous]
    [SecurityHeaders]
    public class IndexModel : PageModel
    {
        private readonly IMailService _mailService;
        private readonly ILocalUserService _localUserService;
        private readonly INotyfService _notificationService;

        public IndexModel(
            IMailService mailService, 
            ILocalUserService localUserService,
            INotyfService notificationService)
        {
            _mailService = mailService;
            _localUserService = localUserService;
            _notificationService = notificationService;
        }
        public IActionResult OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl;
            Input = new InputModel();
            return Page();
        }

        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]
        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _localUserService.GetUserByEmailAsync(Input.Email);

            if (user == null)
            {
                ModelState.AddModelError("Input.Email", "Email chưa được dùng để đăng ký tài khoản nào.");
                return Page();
            }

            var token = _localUserService.GeneratePasswordResetToken(user);
            var resetPasswordLink = Url.Page("/User/ResetPassword/Index", null, new 
                { 
                    token, 
                    email = user.Email, 
                    returnUrl = ReturnUrl 
                },
                Request.Scheme
            );

            var emailSent = await _mailService.SendMailAsync(new MailRequest()
            {
                ReceiverEmail = user.Email!,
                ReceiverName = user.UserName ?? string.Empty,
                EmailSubject = "Đặt lại mật khẩu",
                EmailBody = $"Nhấn vào link để đặt lại mật khẩu: {resetPasswordLink}"
            });

            if (!emailSent)
            {
                _notificationService.Error("Có lỗi xảy ra. Vui lòng thử lại sau.");
                return Redirect("/Account/Login");
            }

            return Redirect("/User/ForgotPasswordConfirmation");
        }
    }
}
