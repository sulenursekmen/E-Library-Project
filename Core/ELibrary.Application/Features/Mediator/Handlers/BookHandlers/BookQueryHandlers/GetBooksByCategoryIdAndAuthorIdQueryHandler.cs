using ELibrary.Application.Features.Mediator.Queries.BookQueries;
using ELibrary.Application.Features.Mediator.Results.BookResults;
using ELibrary.Application.Interfaces;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Handlers.BookHandlers.BookQueryHandlers
{
    public class GetBooksByCategoryIdAndAuthorIdQueryHandler : IRequestHandler<GetBooksByCategoryIdAndAuthorIdQuery, List<GetBooksByCategoryIdAndAuthorIdQueryResult>>
    {
        private readonly IBookRepository _repository;

        public GetBooksByCategoryIdAndAuthorIdQueryHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBooksByCategoryIdAndAuthorIdQueryResult>> Handle(GetBooksByCategoryIdAndAuthorIdQuery request, CancellationToken cancellationToken)
        {
            var allBooks = await _repository.GetAllBookWithCategoryAndAuthorAsync(); 

            var books = allBooks
                .Where(b => b.CategoryId == request.CategoryId && b.AuthorId == request.AuthorId)
                .Select(b => new GetBooksByCategoryIdAndAuthorIdQueryResult
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
