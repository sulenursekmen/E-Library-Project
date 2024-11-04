using AutoMapper;
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
    public class CreateUserBookCommandHandler : IRequestHandler<CreateUserBookCommand, Unit>
    {
        private readonly IRepository<UserBook> _repository;
        private readonly IMapper _mapper;

        public CreateUserBookCommandHandler(IRepository<UserBook> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateUserBookCommand request, CancellationToken cancellationToken)
        {
            var userBookEntity = _mapper.Map<UserBook>(request);
            await _repository.CreateAsync(userBookEntity);

            return Unit.Value;

        }
    }
}