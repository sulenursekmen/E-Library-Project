using ELibrary.Application.Features.Mediator.Results.BookResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Queries.BookQueries
{
    public class GetBooksByPublishedDateQuery : IRequest<List<GetBooksByPublishedDateQueryResult>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetBooksByPublishedDateQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
