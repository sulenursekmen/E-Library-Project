﻿using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.LayoutViewComponents
{
    public class _FooterLayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
