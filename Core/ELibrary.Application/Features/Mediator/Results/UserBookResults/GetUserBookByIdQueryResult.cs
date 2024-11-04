using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Results.UserBookResults
{
    public class GetUserBookByIdQueryResult
    {
        public int UserBookId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
