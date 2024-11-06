using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.HomeViewComponents
{
    public class _SearchbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() { return View(); }
    }
}
