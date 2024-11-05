using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ELibrary.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }                 
        public string Name { get; set; }            
        public string Biography { get; set; }      
        public DateTime BirthDate { get; set; }    
        public string Nationality { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
