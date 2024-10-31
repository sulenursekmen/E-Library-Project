using AutoMapper;
using ELibrary.Application.Features.CQRS.Commands.CategoryCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommand command)
        {
            var existingCategory = await _repository.GetByIdAsync(command.CategoryId);
            _mapper.Map(command, existingCategory);
            await _repository.UpdateAsync(existingCategory);
        }
    }
}