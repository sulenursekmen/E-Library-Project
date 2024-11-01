using ELibrary.Domain.Entities;
using ELibrary.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELibrary.WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
       private readonly UserManager<ApplicationUser> _userManager;

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var model = new ApplicationUserViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Gender = user.Gender,
                Bio = user.Bio,
                ProfilePictureUrl = user.ProfilePictureUrl
            };

            // Cinsiyet seçeneklerini oluştur
            ViewBag.GenderOptions = new SelectList(new[]
            {
            new { Value = "Male", Text = "Erkek" },
            new { Value = "Female", Text = "Kadın" },
            new { Value = "Other", Text = "Diğer" }
        }, "Value", "Text", model.Gender);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ApplicationUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    // Kullanıcının bilgilerini güncelle
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Gender = model.Gender;
                    user.Bio = model.Bio;
                    user.ProfilePictureUrl = model.ProfilePictureUrl; // Profil resmi URL'sini güncelle

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index"); // Güncellemeler başarılı ise profil sayfasına geri dön
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description); // Hataları ekle
                    }
                }
            }

            // Hatalıysa güncellenen model ile tekrar göster
            ViewBag.GenderOptions = new SelectList(new[]
            {
            new { Value = "Male", Text = "Erkek" },
            new { Value = "Female", Text = "Kadın" },
            new { Value = "Other", Text = "Diğer" }
        }, "Value", "Text", model.Gender);

            return View(model);
        }


    }
}
