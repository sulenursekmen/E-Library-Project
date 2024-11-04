using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELibrary.Domain.Entities
{
    public class UserBook
    {
        public int UserBookId { get; set; } 
        public int UserId { get; set; } 
        public int BookId { get; set; } 
        public DateTime DateAdded { get; set; } 
        public ApplicationUser User { get; set; } 
        public Book Book { get; set; } 
    }
}
