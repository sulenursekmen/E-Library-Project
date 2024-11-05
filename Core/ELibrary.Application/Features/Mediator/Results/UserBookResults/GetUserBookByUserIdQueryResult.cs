using ELibrary.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Results.UserBookResults
{
    public class GetUserBookByUserIdQueryResult
    {
        public int UserBookId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public DateTime DateAdded { get; set; }
        public Book Book { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}
