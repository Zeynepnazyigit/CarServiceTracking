using FluentValidation;
using CarServiceTracking.Core.DTOs.CustomerDTOs;

namespace CarServiceTracking.Business.Validation.Auth
{
    /// <summary>
    /// Login DTO validation
    /// </summary>
    public class CustomerLoginDTOValidator : AbstractValidator<CustomerLoginDTO>
    {
        public CustomerLoginDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi gereklidir")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre gereklidir")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır");
        }
    }

    /// <summary>
    /// Register DTO validation - password policy ile
    /// </summary>
    public class CustomerSignupDTOValidator : AbstractValidator<CustomerSignupDTO>
    {
        public CustomerSignupDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad gereklidir")
                .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olmalıdır");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyadı gereklidir")
                .MaximumLength(100).WithMessage("Soyadı en fazla 100 karakter olmalıdır");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta adresi gereklidir")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre gereklidir")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır")
                .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
                .Matches(@"[!@#$%^&*()_+\-=\[\]{};:'"",.<>?/\\|`~]").WithMessage("Şifre en az bir özel karakter içermelidir");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numarası gereklidir")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Geçerli bir telefon numarası giriniz");
        }
    }
}
