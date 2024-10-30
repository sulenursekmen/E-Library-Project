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

       
       public DbSet<Category> Categories { get; set; }
    }

}
