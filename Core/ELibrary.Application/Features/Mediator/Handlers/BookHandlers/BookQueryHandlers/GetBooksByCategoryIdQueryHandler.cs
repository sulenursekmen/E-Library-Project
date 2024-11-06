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
    public class GetBooksByCategoryIdQueryHandler : IRequestHandler<GetBooksByCategoryIdQuery, List<GetBooksByCategoryIdQueryResult>>
    {
        private readonly IBookRepository _repository;

        public GetBooksByCategoryIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBooksByCategoryIdQueryResult>> Handle(GetBooksByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var allBooks = await _repository.GetAllBookWithCategoryAndAuthorAsync();

            var books = allBooks
                .Where(b => b.CategoryId == request.CategoryId)
                .Select(b => new GetBooksByCategoryIdQueryResult
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    PublishedDate = b.PublishedDate,
                    Description = b.Description,
                    CoverImageUrl = b.CoverImageUrl,
                    PublisherName = b.PublisherName,
                    AuthorName = b.Author.Name,
                    CategoryName = b.Category.CategoryName
                })
                .ToList();

            if (!books.Any())
            {
                throw new KeyNotFoundException("Not found book.");
            }

            return books;
        }
    }

}
