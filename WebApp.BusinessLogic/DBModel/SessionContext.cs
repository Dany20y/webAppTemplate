using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Domain.Entities.User;

namespace WebApp.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name = App")
        {
        }
        public virtual DbSet<Session> Sessions { get; set; }
    }
}