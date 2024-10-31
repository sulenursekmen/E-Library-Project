using AutoMapper;
using ELibrary.Application.Features.CQRS.Commands.CategoryCommands;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateCategoryCommand createCategoryCommand)
        {
            var category = _mapper.Map<Category>(createCategoryCommand);
            await _repository.CreateAsync(category);
        }
    }
}
