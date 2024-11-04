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
    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdQueryResult>
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public GetBookByIdQueryHandler(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetBookByIdQueryResult> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);
            var result=_mapper.Map<GetBookByIdQueryResult>(book);
            return result;
        }
    }
}
