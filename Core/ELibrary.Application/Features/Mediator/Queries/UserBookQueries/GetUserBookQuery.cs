using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using MediatR;

namespace ELibrary.Application.Features.Mediator.Queries.UserBookQueries
{
    public class GetUserBookQuery : IRequest<List<GetUserBookQueryResult>>
    {
    }
}
