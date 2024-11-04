using AutoMapper;
using ELibrary.Application.Features.CQRS.Commands.CategoryCommands;
using ELibrary.Application.Features.Mediator.Commands.AuthorCommands;
using ELibrary.Application.Features.Mediator.Results.AuthorResults;
using ELibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            //Category Mapping
            CreateMap<Category,CreateCategoryCommand>().ReverseMap();
            CreateMap<Category,UpdateCategoryCommand>().ReverseMap();

            //Author Mapping
            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryResult>();
            CreateMap<Author, GetAuthorQueryResult>();
        }
    }
}
