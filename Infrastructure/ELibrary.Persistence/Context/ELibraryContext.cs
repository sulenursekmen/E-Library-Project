using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ELibrary.Persistence.Context
{


    public class ELibraryContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ELibraryContext(DbContextOptions<ELibraryContext> options) : base(options)
        {
        }

       public DbSet<Author> Authors { get; set; }  
       public DbSet<Book> Books { get; set; }
       public DbSet<Category> Categories { get; set; }
       public DbSet<UserBook> UserBooks { get; set; }

    }

}
