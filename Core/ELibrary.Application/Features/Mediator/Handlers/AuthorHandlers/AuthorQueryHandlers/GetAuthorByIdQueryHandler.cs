using AutoMapper;
using ELibrary.Application.Features.Mediator.Queries.AuthorQueries;
using ELibrary.Application.Features.Mediator.Results.AuthorResults;
using ELibrary.Application.Interfaces;
using ELibrary.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.AuthorHandlers.AuthorQueryHandlers
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResult>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetAuthorByIdQueryResult> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _repository.GetByIdAsync(request.Id);
            var result = _mapper.Map<GetAuthorByIdQueryResult>(author);
            return result;
        }
    }
}
