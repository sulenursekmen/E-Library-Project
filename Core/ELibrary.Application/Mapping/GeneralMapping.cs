using AutoMapper;
using ELibrary.Application.Features.CQRS.Commands.CategoryCommands;
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
        }
    }
}
