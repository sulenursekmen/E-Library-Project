using ELibrary.Application.Features.Mediator.Commands.BookCommands;
using ELibrary.Application.Features.Mediator.Queries.BookQueries;
using ELibrary.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBookRepository _bookRepository;

        public BooksController(IMediator mediator, IBookRepository bookRepository)
        {
            _mediator = mediator;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> BookList()
        {
            var values = await _mediator.Send(new GetBookQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            var values = await _mediator.Send(new GetBookByIdQuery(id));
            return Ok(values);
        }
        [HttpGet("category/{categoryId}/author/{authorId}")]
        public async Task<IActionResult> GetBooksByCategoryAndAuthor(int categoryId, int authorId)
        {
            var query = new GetBooksByCategoryIdAndAuthorIdQuery
            {
                CategoryId = categoryId,
                AuthorId = authorId
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetBooksByCategory(int categoryId)
        {
            var query = new GetBooksByCategoryIdQuery
            {
                CategoryId = categoryId,

            };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("byPublishedDate")]

        public async Task<IActionResult> GetBooksByPublishedDate(DateTime startDate, DateTime endDate)
        {
            startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
            endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

            var books = await _bookRepository.GetBooksByPublishedDateAsync(startDate, endDate);
            return Ok(books);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok("The Book has been created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveBook(int id)
        {
            await _mediator.Send(new RemoveBookCommand(id));
            return Ok("The Book has been deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBook(UpdateBookCommand command)
        {
            await _mediator.Send(command);
            return Ok("The Book has been updated successfully");
        }
    }
}
