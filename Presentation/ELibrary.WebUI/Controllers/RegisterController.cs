using ELibrary.Application.Features.CQRS.Commands.ApplicationUserCommands;
using ELibrary.Application.ValidationRules.ApplicationUserValidationRules;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using ELibrary.WebUI.Services.EmailServices;

namespace ELibrary.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;

        public RegisterController(UserManager<ApplicationUser> userManager, IEmailService emailService)
        {
            _userManager = userManager;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApplicationUserRegisterCommand model)
        {
            var validator = new ApplicationUserRegisterValidator();
            var validationResult = await validator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }

            if (ModelState.IsValid)
            {
                Random random = new Random();
                string confirmCode = random.Next(100000, 1000000).ToString();
                ApplicationUser applicationUser = new ApplicationUser()
                {
                    UserName = model.Username,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    ConfirmCode = confirmCode,
                };

                var result = await _userManager.CreateAsync(applicationUser, model.Password);
                if (result.Succeeded)
                {
                    string subject = "E-Kütüphane Kayıt için Onay Kodu";
                    string message = "Kayıt işlemini tamamlamak için onay kodunuz : " + confirmCode + "\n";

                    await _emailService.SendEmailAsync(applicationUser.Email, subject, message);

                    TempData["Email"] = model.Email;

                    return RedirectToAction("Index", "ConfirmMail");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        #region deleted
        //[HttpPost]
        //public async Task<IActionResult> Index(ApplicationUserRegisterCommand model)
        //{
        //    var validator = new ApplicationUserRegisterValidator();
        //    var validationResult = await validator.ValidateAsync(model);

        //    if (!validationResult.IsValid)
        //    {
        //        foreach (var error in validationResult.Errors)
        //        {
        //            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        //        }
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var applicationUser = new ApplicationUser()
        //        {
        //            UserName = model.Username,
        //            Email = model.Email,
        //            FirstName = model.FirstName,
        //            LastName = model.LastName,
        //            Gender = model.Gender
        //        };

        //        var result = await _userManager.CreateAsync(applicationUser, model.Password);
        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "ConfirmMail");
        //        }
        //        else
        //        {
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);
        //            }
        //        }
        //    }

        //    // Hata varsa model ile birlikte geri dön
        //    return View(model);
        //}
        #endregion
    }
}
