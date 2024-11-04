

using ELibrary.Application.Features.Mediator.Commands.CategoryCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Handlers.CategoryHandlers.CategoryCommandHandlers
{
    public class RemoveCategoryCommandHandler:IRequestHandler<RemoveCategoryCommand,Unit>
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
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
