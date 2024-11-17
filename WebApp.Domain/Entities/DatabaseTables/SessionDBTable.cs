using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApp.Domain.Entities.User;

namespace WebApp.Domain.Entities.DatabaseTables
{
    public class SessionDBTable
    {
        [Key]
        public string SessionId { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey(nameof(UserId))]
        public virtual UserDBTable User { get; set; }

        public int UserId { get; set; }
        public CookieBuilder Cookie { get; set; }
    }
}