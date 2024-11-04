using AutoMapper;
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
    public class CreateBookCommandHandler:IRequestHandler<CreateBookCommand,Unit>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var bookEntity=_mapper.Map<Book>(request);

            await _repository.CreateAsync(bookEntity);

            return Unit.Value;
        }
    }
}
