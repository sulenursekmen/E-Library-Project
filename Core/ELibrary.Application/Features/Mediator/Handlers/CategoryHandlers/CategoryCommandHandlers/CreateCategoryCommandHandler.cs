using AutoMapper;
using ELibrary.Application.Features.Mediator.Commands.CategoryCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Handlers.CategoryHandlers.CategoryCommandHandlers
{
    public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,Unit>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request);
            await _repository.CreateAsync(category);

            return Unit.Value;
        }
    }
}
