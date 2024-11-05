using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ELibrary.Domain.Entities
{
    public class UserBook
    {
        public int UserBookId { get; set; } 
        public int UserId { get; set; } 
        public int BookId { get; set; } 
        public int AuthorId { get; set; } 
        public int CategoryId { get; set; } 
        public DateTime DateAdded { get; set; } 

        public ApplicationUser User { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [JsonIgnore]
        public Author Author { get; set; }
    }
}
