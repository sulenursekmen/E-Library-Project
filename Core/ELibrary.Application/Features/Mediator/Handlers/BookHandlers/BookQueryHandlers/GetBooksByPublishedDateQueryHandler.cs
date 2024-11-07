using AutoMapper;
using ELibrary.Application.Features.Mediator.Queries.BookQueries;
using ELibrary.Application.Features.Mediator.Results.BookResults;
using ELibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.BookHandlers.BookQueryHandlers
{
    public class GetBooksByPublishedDateQueryHandler : IRequestHandler<GetBooksByPublishedDateQuery, List<GetBooksByPublishedDateQueryResult>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksByPublishedDateQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<GetBooksByPublishedDateQueryResult>> Handle(GetBooksByPublishedDateQuery request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBooksByPublishedDateAsync(request.StartDate, request.EndDate);

            return _mapper.Map<List<GetBooksByPublishedDateQueryResult>>(books);
        }
    }
}
