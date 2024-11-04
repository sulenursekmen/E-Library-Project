using ELibrary.Application.Features.Mediator.Results.BookResults;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Queries.BookQueries
{
    public class GetBookQuery : IRequest<List<GetBookQueryResult>>
    {
    }
}
