using Labb3Api_V2.Models;
using Microsoft.EntityFrameworkCore;

namespace Labb3Api_V2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<PersonHobby> PersonHobbies { get; set; }
        public DbSet<WebLink> WebLinks { get; set; }
    }
}
