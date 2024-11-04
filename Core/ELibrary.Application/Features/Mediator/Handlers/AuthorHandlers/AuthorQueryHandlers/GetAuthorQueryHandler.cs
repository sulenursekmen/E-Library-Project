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
    public class GetAuthorQueryHandler:IRequestHandler<GetAuthorQuery,List<GetAuthorQueryResult>>
    {
        private readonly IRepository<Author> _repository;
        private readonly IMapper _mapper;

        public GetAuthorQueryHandler(IRepository<Author> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<GetAuthorQueryResult>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _repository.GetAllAsync();

            var result = _mapper.Map<List<GetAuthorQueryResult>>(authors);

            return result;
        }
    }
}
