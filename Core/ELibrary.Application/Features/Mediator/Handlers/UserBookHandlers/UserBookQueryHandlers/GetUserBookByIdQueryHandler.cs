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
    public class GetUserBookByIdQueryHandler : IRequestHandler<GetUserBookByIdQuery, GetUserBookByIdQueryResult>
    {
        private readonly IRepository<UserBook> _repository;
        private readonly IMapper _mapper;

        public GetUserBookByIdQueryHandler(IRepository<UserBook> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetUserBookByIdQueryResult> Handle(GetUserBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetUserBookByIdQueryResult>(book);
            return result;
        }
    }
}
