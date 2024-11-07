using ELibrary.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.ViewComponents.MyLibraryViewComponents
{
    public class _BookDateFilterViewComponentPartial:ViewComponent
    {
        private readonly IBookRepository _bookRepository;

        public _BookDateFilterViewComponentPartial(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime startDate, DateTime endDate)
        {  
            if (startDate == default || endDate == default)
            {
                ModelState.AddModelError("", "Lütfen geçerli bir tarih aralığı girin.");
                return View();
            }

            var books = await _bookRepository.GetBooksByPublishedDateAsync(startDate, endDate);
            return View("Filter", books);
       
        }
    }
}
