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
    public class UpdateUserBookCommandHandler : IRequestHandler<UpdateUserBookCommand, Unit>
    {
        private readonly IRepository<UserBook> _repository;
        private readonly IMapper _mapper;

        public UpdateUserBookCommandHandler(IRepository<UserBook> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateUserBookCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.UserBookId);
            if (values != null)
            {
                _mapper.Map(request, values);
                await _repository.UpdateAsync(values);
            }

            return Unit.Value;
        }
    }
}
