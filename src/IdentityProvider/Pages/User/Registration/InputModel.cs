using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace IdentityProvider.Pages.User.Registration
{
    public class InputModel
    {
        public string? ReturnUrl { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Vui lòng điền tên đăng nhập.")]
        [MaxLength(100, ErrorMessage = "Tên đăng nhập không được vượt quá 100 ký tự.")]
        public string UserName { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng điền mật khẩu.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự.")]
        public string Password { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu không khớp.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Tên")]
        [Required(ErrorMessage = "Vui lòng điền tên.")]
        [MaxLength(100, ErrorMessage = "Tên không được vượt quá 100 ký tự.")]
        public string GivenName { get; set; }

        [Display(Name = "Họ")]
        [Required(ErrorMessage = "Vui lòng điền họ.")]
        [MaxLength(100, ErrorMessage = "Họ không được vượt quá 100 ký tự.")]
        public string FamilyName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Vui lòng điền địa chỉ email.")]
        [MaxLength(100, ErrorMessage = "Địa chỉ email không được vượt quá 100 ký tự.")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ.")]
        public string Email { get; set; }

        [Display(Name = "Quốc gia")]
        [Required(ErrorMessage = "Vui lòng điền quốc gia.")]
        [MaxLength(2, ErrorMessage = "Quốc gia không hợp lệ.")]
        public string Country { get; set; }

        public SelectList CountryCodes { get; set; } = new(
                new[]
                {
                    new { Id = "vn", Value = "Vietnam" },
                    new { Id = "us", Value = "America" }
                }, "Id", "Value"
            );

    }
     
}
