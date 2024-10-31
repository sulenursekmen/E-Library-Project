using ELibrary.Application.Features.CQRS.Commands.ApplicationUserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.ValidationRules.ApplicationUserValidationRules
{
    public class ApplicationUserRegisterValidator : AbstractValidator<ApplicationUserRegisterCommand>
    {
        public ApplicationUserRegisterValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("İsim alanı boş bırakılamaz")
                .Length(2, 50).WithMessage("İsim 2 ile 50 karakter arasında olmalıdır");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyisim alanı boş bırakılamaz")
                .Length(2, 50).WithMessage("Soyisim 2 ile 50 karakter arasında olmalıdır");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Kullanıcı adı alanı boş bırakılamaz")
                .Length(3, 20).WithMessage("Kullanıcı adı 3 ile 20 karakter arasında olmalıdır");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş bırakılamaz")
                .MinimumLength(8).WithMessage("Şifre en az 8 karakter olmalıdır")
                .Matches("[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir")
                .Matches("[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir")
                .Matches("[0-9]").WithMessage("Şifre en az bir rakam içermelidir")
                .Matches("[^a-zA-Z0-9]").WithMessage("Şifre en az bir özel karakter içermelidir");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Şifre onayı boş bırakılamaz")
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş bırakılamaz")
                .Length(2, 50).WithMessage("Şehir adı 2 ile 50 karakter arasında olmalıdır");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz")
                .Must(BeAValidAge).WithMessage("Geçerli bir yaş giriniz");

            RuleFor(x => x.ImageUrl)
                .Must(BeAValidUrl).WithMessage("Geçerli bir URL giriniz").When(x => !string.IsNullOrEmpty(x.ImageUrl));

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz")
                .Must(g => g == "Male" || g == "Female" || g == "Other")
                .WithMessage("Cinsiyet 'Male', 'Female' veya 'Other' olmalıdır");
        }

        private bool BeAValidAge(DateTime date)
        {
            int age = DateTime.Today.Year - date.Year;
            if (date > DateTime.Today.AddYears(-age)) age--;
            return age >= 6;
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out _);
        }
    }

}
