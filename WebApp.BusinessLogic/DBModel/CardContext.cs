using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Domain.Entities.DatabaseTables;

namespace WebApp.BusinessLogic.DBModel
{
    public class CardContext : DbContext
    {
        public CardContext() :
        base("name = Dani")
        {
        }
        public virtual DbSet<CoCardDBTable> Card_Table { get; set; }
    }
}