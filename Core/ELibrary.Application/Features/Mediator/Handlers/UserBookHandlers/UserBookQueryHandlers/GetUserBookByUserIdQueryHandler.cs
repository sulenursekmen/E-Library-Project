using ELibrary.Application.Features.Mediator.Queries.UserBookQueries;
using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using ELibrary.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Handlers.UserBookHandlers.UserBookQueryHandlers
{
    public class GetUserBookByUserIdQueryHandler : IRequestHandler<GetUserBookByUserIdQuery, List<GetUserBookByUserIdQueryResult>>
    {
        private readonly IUserBookRepository _repository;

        public GetUserBookByUserIdQueryHandler(IUserBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetUserBookByUserIdQueryResult>> Handle(GetUserBookByUserIdQuery request, CancellationToken cancellationToken)
        {
            // Kullanıcıya ait kitapları al
            var userBooks = await _repository.GetUserBooksByUserIdAsync(request.UserId);

            // Sonuçları uygun formatta döndür
            return userBooks.Select(ub => new GetUserBookByUserIdQueryResult
            {
                UserBookId = ub.UserBookId,
                UserId = ub.UserId,
                BookId = ub.BookId,
                DateAdded = ub.DateAdded,
                Book = ub.Book ,
                Category=ub.Category,
                Author=ub.Author
                // Eğer Book nesnesini detaylı olarak döndürmek istemiyorsanız bunu kaldırabilirsiniz.
            }).ToList();
        }
    }
}
