using System.Data.Entity;
using WebApp.Domain.Entities.DatabaseTables;

namespace WebApp.BusinessLogic.DBModel
{
    public class CardContext : DbContext
    {
        public CardContext() : base("name=Dani")
        {
        }

        public DbSet<CoCardDBTable> Card_Table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoCardDBTable>().ToTable("CoCardDBTables"); // Maparea corectă a tabelului
            base.OnModelCreating(modelBuilder);
        }
    }
}
