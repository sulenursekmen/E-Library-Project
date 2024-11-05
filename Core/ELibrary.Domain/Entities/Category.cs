using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ELibrary.Domain.Entities
{
    public class Category
    {
        public int CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; }
    }
}
