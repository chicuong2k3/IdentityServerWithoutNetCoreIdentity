using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Pages.User.ForgotPassword
{
    public class InputModel
    {
        [Required(ErrorMessage = "Vui lòng điền địa chỉ email.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
