using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string PublisherName { get; set; }

        public Author Author { get; set; }
        public Category Category { get; set; }

    }
}
