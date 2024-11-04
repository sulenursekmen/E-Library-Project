using AutoMapper;
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
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Unit>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var authorEntity = _mapper.Map<Author>(request);

            await _repository.CreateAsync(authorEntity);

            return Unit.Value;
        }
    }
}
