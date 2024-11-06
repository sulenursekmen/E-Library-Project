﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Application.Features.Mediator.Results.BookResults
{
    public class GetBooksByCategoryIdQueryResult
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Description { get; set; }
        public string CoverImageUrl { get; set; }
        public string AuthorName { get; set; }
        public string CategoryName { get; set; }
        public string PublisherName { get; set; }
    }
}
