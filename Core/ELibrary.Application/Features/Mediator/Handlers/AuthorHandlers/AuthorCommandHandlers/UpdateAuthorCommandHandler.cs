using AutoMapper;
using ELibrary.Application.Features.Mediator.Commands.AuthorCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorCommandHandlers
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AuthorId);
            if (values != null)
            {
                _mapper.Map(request, values);
                await _repository.UpdateAsync(values);

            }
            return Unit.Value;
        }
    }
}
