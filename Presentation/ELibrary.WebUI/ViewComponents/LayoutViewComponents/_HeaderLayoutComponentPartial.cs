using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.LayoutViewComponents
{
    public class _HeaderLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
