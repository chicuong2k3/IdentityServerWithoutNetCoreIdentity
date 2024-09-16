// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace IdentityProvider.Pages.Account.Login;

public class InputModel
{
    [Required(ErrorMessage = "Vui lòng điền tên đăng nhập.")]
    [Display(Name = "Tên đăng nhập")]
    public string? Username { get; set; }

    [Required(ErrorMessage = "Vui lòng điền mật khẩu.")]
    [Display(Name = "Mật khẩu")]
    public string? Password { get; set; }
    public bool RememberLogin { get; set; }

    [Required(ErrorMessage = "Vui lòng điền mã xác thực.")]
    [Display(Name = "Mã xác thực")]
    public string Totp { get; set; }
    public string? ReturnUrl { get; set; }
    public string? Button { get; set; }
}