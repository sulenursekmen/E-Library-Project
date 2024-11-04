using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Queries.UserBookQueries
{
    public class GetUserBookByIdQuery : IRequest<GetUserBookByIdQueryResult>
    {
        public int Id { get; set; }

        public GetUserBookByIdQuery(int id)
        {
            Id = id;
        }
    }
}
