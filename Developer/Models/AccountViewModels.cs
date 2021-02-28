using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Developer.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Zły format adreu e-mail.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [DataType(DataType.Password, ErrorMessage = "Zły format")]
        [Display(Name = "Hasło")] public string Password { get; set; }
        [Display(Name = "Zapamiętaj mnie?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Zły format adresu e-mail.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [StringLength(100, ErrorMessage = "Wprowadź {0} (min. {2} znaków)", MinimumLength = 6)]
        [DataType(DataType.Password, ErrorMessage = "Zły format")]
        [Display(Name = "Hasło")]
        public string Password { get; set; }
        [DataType(DataType.Password, ErrorMessage = "Zły format")]
        [Display(Name = "Powtórz hasło")]
        [Compare("Password", ErrorMessage = "Hasła muszą się zgadzać.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Pole imię jest wymagane.")]
        [Display(Name = "Imię")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Pole nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
