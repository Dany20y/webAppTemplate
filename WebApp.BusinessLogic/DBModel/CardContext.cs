using System.Data.Entity;
using WebApp.Domain.Entities.DatabaseTables;

namespace WebApp.BusinessLogic.DBModel
{
    public class CardContext : DbContext // Schimbă la public
    {
        public CardContext() : base("name=Dani")
        {
        }

        public DbSet<CoCardDBTable> Cards { get; set; }
    }
}
