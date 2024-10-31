using ELibrary.Application.Features.CQRS.Commands.ApplicationUserCommands;
using ELibrary.Application.Features.CQRS.Handlers.ApplicationUserCommandHandlers;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationUserRegisterCommandHandler _userRegisterCommandHandler;

        public AccountController(ApplicationUserRegisterCommandHandler userRegisterCommandHandler)
        {
            _userRegisterCommandHandler = userRegisterCommandHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ApplicationUserRegisterCommand registerCommand)
        {
            await _userRegisterCommandHandler.Handle(registerCommand);
            return Ok($"The user '{registerCommand.Username}' has been registered successfully.");
        }
    }
}

