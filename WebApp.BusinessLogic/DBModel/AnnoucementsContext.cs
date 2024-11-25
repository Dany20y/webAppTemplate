using System.Data.Entity;
using WebApp.Domain.Entities.DatabaseTables;

namespace WebApp.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=Dani")
        {
        }

        public DbSet<Announcement> Announcements { get; set; }
    }
}
