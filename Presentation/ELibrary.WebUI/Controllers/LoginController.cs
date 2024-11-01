using ELibrary.Domain.Entities;
using ELibrary.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace ELibrary.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Kullanıcıyı email ile buluyoruz
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Bu e-posta adresine kayıtlı bir kullanıcı bulunamadı.");
                return View(model);
            }

            // Email onaylanmış mı kontrol ediyoruz
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "E-posta adresiniz henüz onaylanmamış. Lütfen e-posta adresinize gelen onay kodunu kullanarak hesabınızı onaylayın.");
                return View(model);
            }

            // Kullanıcıyı şifre ile doğruluyoruz
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home"); // Giriş başarılıysa anasayfaya yönlendirin
            }
            else
            {
                ModelState.AddModelError("", "Geçersiz giriş denemesi. Lütfen e-posta ve şifrenizi kontrol edin.");
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}
