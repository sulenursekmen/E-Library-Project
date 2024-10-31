using ELibrary.Application.Features.CQRS.Commands.ApplicationUserCommands;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ELibrary.Application.Features.CQRS.Handlers.ApplicationUserCommandHandlers
{
    public class ApplicationUserRegisterCommandHandler
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserRegisterCommandHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(ApplicationUserRegisterCommand command)
        {
            if (command.Password != command.ConfirmPassword)
            {
                return false; 
            }

            var user = new ApplicationUser
            {
                UserName = command.Username,
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                Gender = command.Gender,
                IsActive = true
            };

            var result = await _userManager.CreateAsync(user, command.Password);

            return result.Succeeded; 
        }
    }
}
