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
                .NotEmpty().WithMessage("Adı alanı boş bırakılamaz")
                .Length(2, 50).WithMessage("İsim 2 ile 50 karakter arasında olmalıdır");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Soyadı alanı boş bırakılamaz")
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
                .NotEmpty().WithMessage("Şifre tekrarı boş bırakılamaz")
                .Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Cinsiyet alanı boş bırakılamaz")
                .Must(g => g == "Male" || g == "Female" || g == "Other")
                .WithMessage("Cinsiyet 'Male', 'Female' veya 'Other' olmalıdır");
        }

      
    }

}
