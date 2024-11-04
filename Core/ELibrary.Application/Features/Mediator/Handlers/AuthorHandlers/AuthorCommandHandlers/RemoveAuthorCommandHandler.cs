using ELibrary.Application.Features.Mediator.Commands.AuthorCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorCommandHandlers
{
    public class RemoveAuthorCommandHandler : IRequestHandler<RemoveAuthorCommand, Unit>
    {
        private readonly IRepository<Author> _repository;

        public RemoveAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveAuthorCommand request, CancellationToken cancellationToken)
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
