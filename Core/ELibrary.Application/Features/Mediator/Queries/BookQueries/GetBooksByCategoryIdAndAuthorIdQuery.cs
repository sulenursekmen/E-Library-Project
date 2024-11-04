using ELibrary.Application.Features.Mediator.Results.BookResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Queries.BookQueries
{
    public class GetBooksByCategoryIdAndAuthorIdQuery : IRequest<List<GetBooksByCategoryIdAndAuthorIdQueryResult>>
    {
        public int CategoryId { get; set; }  
        public int AuthorId { get; set; }
    }
}
