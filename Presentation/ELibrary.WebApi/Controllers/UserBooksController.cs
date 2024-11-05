using ELibrary.Application.Features.Mediator.Commands.UserBookCommands;
using ELibrary.Application.Features.Mediator.Queries.UserBookQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserBooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserBooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> UserBookList()
        {
            var values = await _mediator.Send(new GetUserBookQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserBookById(int id)
        {
            var values = await _mediator.Send(new GetUserBookByIdQuery(id));
            return Ok(values);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserBooksByUserId(int userId)
        {
            var userBooks = await _mediator.Send(new GetUserBookByUserIdQuery(userId));
            return Ok(userBooks);
        }


        [HttpPost]
        public async Task<IActionResult> CreateUserBook(CreateUserBookCommand command)
        {
            await _mediator.Send(command);
            return Ok("The UserBook has been created successfully");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUserBook(int id)
        {
            await _mediator.Send(new RemoveUserBookCommand(id));
            return Ok("The UserBook has been deleted successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserBook(UpdateUserBookCommand command)
        {
            await _mediator.Send(command);
            return Ok("The UserBook has been updated successfully");
        }
    }
}
