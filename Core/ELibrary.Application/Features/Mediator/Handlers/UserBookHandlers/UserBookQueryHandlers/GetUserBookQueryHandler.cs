using AutoMapper;
using ELibrary.Application.Features.Mediator.Queries.BookQueries;
using ELibrary.Application.Features.Mediator.Queries.UserBookQueries;
using ELibrary.Application.Features.Mediator.Results.BookResults;
using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.UserBookHandlers.UserBookQueryHandlers
{
    public class GetUserBookQueryHandler : IRequestHandler<GetUserBookQuery, List<GetUserBookQueryResult>>
    {
        private readonly IRepository<UserBook> _repository;
        private readonly IMapper _mapper;

        public GetUserBookQueryHandler(IRepository<UserBook> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetUserBookQueryResult>> Handle(GetUserBookQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();

            var result = _mapper.Map<List<GetUserBookQueryResult>>(books);

            return result;
        }
    }
}
