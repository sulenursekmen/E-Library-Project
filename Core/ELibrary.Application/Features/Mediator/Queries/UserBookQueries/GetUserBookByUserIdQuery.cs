using ELibrary.Application.Features.Mediator.Results.UserBookResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Queries.UserBookQueries
{
    public class GetUserBookByUserIdQuery : IRequest<List<GetUserBookByUserIdQueryResult>>
    {
        public int UserId { get; set; }

        public GetUserBookByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
