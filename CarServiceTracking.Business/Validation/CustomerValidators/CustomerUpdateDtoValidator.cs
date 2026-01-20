using CarServiceTracking.Core.DTOs.CustomerDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarServiceTracking.Business.Validation.CustomerValidators
{
    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDTO>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Geçerli bir müşteri ID'si giriniz.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Ad alanı zorunludur.")
                .MaximumLength(100).WithMessage("Ad maksimum 100 karakter olabilir.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyad alanı zorunludur.")
                .MaximumLength(100).WithMessage("Soyad maksimum 100 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı zorunludur.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
                .MaximumLength(200).WithMessage("Email maksimum 200 karakter olabilir.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon alanı zorunludur.")
                .MinimumLength(10).WithMessage("Telefon numarası minimum 10 karakter olmalıdır.")
                .MaximumLength(20).WithMessage("Telefon numarası maksimum 20 karakter olabilir.");

            RuleFor(x => x.Address)
                .MaximumLength(500).WithMessage("Adres maksimum 500 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.City)
                .MaximumLength(100).WithMessage("Şehir maksimum 100 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.City));

            RuleFor(x => x.TaxNumber)
                .MaximumLength(50).WithMessage("Vergi numarası maksimum 50 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.TaxNumber));

            RuleFor(x => x.CompanyName)
                .MaximumLength(200).WithMessage("Şirket adı maksimum 200 karakter olabilir.")
                .When(x => !string.IsNullOrEmpty(x.CompanyName));
        }
    }
}
