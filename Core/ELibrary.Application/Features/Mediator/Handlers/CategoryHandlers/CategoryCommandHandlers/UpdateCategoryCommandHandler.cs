using AutoMapper;
using ELibrary.Application.Features.Mediator.Commands.AuthorCommands;
using ELibrary.Application.Features.Mediator.Commands.CategoryCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.CategoryHandlers.CategoryCommandHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CategoryId);
            if (values != null)
            {
                _mapper.Map(request, values);
                await _repository.UpdateAsync(values);

            }
            return Unit.Value;
        }
    }
}