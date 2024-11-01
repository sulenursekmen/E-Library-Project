using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.LayoutViewComponents
{
    public class _HeadLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        { 
            return View();
        }
    }
}
