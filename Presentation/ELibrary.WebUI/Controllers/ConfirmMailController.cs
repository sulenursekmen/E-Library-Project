using ELibrary.Domain.Entities;
using ELibrary.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.Controllers
{
    public class ConfirmMailController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public ConfirmMailController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var value = TempData["Email"];
            TempData.Keep("Email");
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ConfirmMailViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string email = TempData["Email"]?.ToString();
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError("", "E-posta bilgisi bulunamadı. Lütfen tekrar kayıt olun.");
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                return View(model);
            }

            if (user.ConfirmCode == model.ConfirmCode)
            {
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                // Ana sayfaya yönlendiriyoruz
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Onay kodu geçersiz.");
            }

            return View(model);
        }
    }

}
