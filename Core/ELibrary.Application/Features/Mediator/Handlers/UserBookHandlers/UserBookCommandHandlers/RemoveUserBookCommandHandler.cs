using ELibrary.Application.Features.Mediator.Commands.BookCommands;
using ELibrary.Application.Features.Mediator.Commands.UserBookCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.UserBookHandlers.UserBookCommandHandlers
{
    public class RemoveUserBookCommandHandler : IRequestHandler<RemoveUserBookCommand, Unit>
    {
        private readonly IRepository<UserBook> _repository;

        public RemoveUserBookCommandHandler(IRepository<UserBook> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveUserBookCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            if (values != null)
            {
                await _repository.DeleteAsync(values);
            }
            return Unit.Value;
        }
    }
}
