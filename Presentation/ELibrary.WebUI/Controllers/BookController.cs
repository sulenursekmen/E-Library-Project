using ELibrary.Application.Features.Mediator.Results.BookResults;
using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebUI.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
  
        private readonly HttpClient _httpClient;
        public BookController(IBookRepository bookRepository, HttpClient httpClient)
        {
            _bookRepository = bookRepository;
            _httpClient = httpClient;
        
        }
        public async Task<IActionResult> Index()
        {
            var booksWithDetails = await _bookRepository.GetAllBookWithCategoryAndAuthorAsync();

            var userBooks = booksWithDetails.Select(book => new GetBooksByCategoryIdAndAuthorIdQueryResult
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate,
                Description = book.Description,
                AuthorName = book.Author.Name,  
                CategoryName = book.Category.CategoryName,
                PublisherName = book.PublisherName,
                CoverImageUrl = book.CoverImageUrl
            }).ToList();

            var responseMessage = await _httpClient.GetAsync("https://localhost:7220/api/Books");

            if (responseMessage.IsSuccessStatusCode)
            {
                var apiBooks = await responseMessage.Content.ReadFromJsonAsync<List<GetBooksByCategoryIdAndAuthorIdQueryResult>>();

                return View(userBooks); 
            }
            else
            {
                var errorMessage = await responseMessage.Content.ReadAsStringAsync();
                return BadRequest($"API Error: {errorMessage}");
            }
        }


    }
}
