using AutoMapper;
using ELibrary.Application.Features.Mediator.Queries.BookQueries;
using ELibrary.Application.Features.Mediator.Results.BookResults;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.BookHandlers.BookQueryHandlers
{
    public class GetBookQueryHandler:IRequestHandler<GetBookQuery,List<GetBookQueryResult>>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public GetBookQueryHandler(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetBookQueryResult>> Handle(GetBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();

            var result=_mapper.Map<List<GetBookQueryResult>>(books);

            return result;
        }
    }
}
