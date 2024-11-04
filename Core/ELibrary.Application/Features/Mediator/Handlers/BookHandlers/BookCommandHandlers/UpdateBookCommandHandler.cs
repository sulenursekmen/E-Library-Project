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
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BookId);
            if (values != null)
            {
                _mapper.Map(request, values);
                await _repository.UpdateAsync(values);
            }

            return Unit.Value;
        }
    }
}
