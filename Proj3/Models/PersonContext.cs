
using Microsoft.EntityFrameworkCore;

namespace Proj3.Models
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Telephone> ServiceNumbers { get; set; }
        public DbSet<Telephone> PersonalNumbers { get; set; }
        public DbSet<Telephone> ServiceMobileNumbers { get; set; }

        public PersonContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;user=root;password=root;database=proj3;",
                new MySqlServerVersion(new Version(8, 0, 20))
            );
        }
    }
}
