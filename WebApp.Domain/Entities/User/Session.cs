using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Domain.Entities.User
{
    public class Session
    {
        public string SessionId { get; set; }
        public virtual User Users { get; set; }
        public CookieBuilder Cookie { get; set; }
    }
}