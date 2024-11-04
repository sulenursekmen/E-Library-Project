﻿using AutoMapper;
using ELibrary.Application.Features.Mediator.Commands.AuthorCommands;
using ELibrary.Application.Features.Mediator.Commands.BookCommands;
using ELibrary.Application.Features.Mediator.Commands.CategoryCommands;
using ELibrary.Application.Features.Mediator.Results.AuthorResults;
using ELibrary.Application.Features.Mediator.Results.BookResults;
using ELibrary.Application.Features.Mediator.Results.CategoryResults;
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
            CreateMap<Category,GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category,GetCategoryQueryResult>().ReverseMap();

            //Author Mapping
            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryResult>();
            CreateMap<Author, GetAuthorQueryResult>();

            //Book Mapping
            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<Book, GetBookByIdQueryResult>();
            CreateMap<Book, GetBookQueryResult>();
        }
    }
}
