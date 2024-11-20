using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Domain.Entities.DatabaseTables;

namespace WebApp.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() :
        base ("name = Dani")
        {
        }
        public virtual DbSet<UserDBTable> Users_Table {  get; set; }
        public virtual DbSet<SessionDBTable> Session_Table { get; set; }
    }
}