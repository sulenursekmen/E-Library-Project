using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.LayoutViewComponents
{
    public class _ScriptLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
