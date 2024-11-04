using ELibrary.Application.Features.Mediator.Commands.BookCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.BookHandlers.BookCommandHandlers
{
    public class RemoveBookCommandHandler : IRequestHandler<RemoveBookCommand, Unit>
    {
        private readonly IRepository<Book> _repository;

        public RemoveBookCommandHandler(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveBookCommand request, CancellationToken cancellationToken)
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