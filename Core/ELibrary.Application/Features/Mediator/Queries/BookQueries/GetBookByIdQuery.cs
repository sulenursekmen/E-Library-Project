using ELibrary.Application.Features.Mediator.Results.BookResults;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Queries.BookQueries
{
    public class GetBookByIdQuery : IRequest<GetBookByIdQueryResult>
    {
        public int Id { get; set; }

        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
