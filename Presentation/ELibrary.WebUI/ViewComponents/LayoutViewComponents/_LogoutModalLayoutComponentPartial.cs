using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.LayoutViewComponents
{
    public class _LogoutModalLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
