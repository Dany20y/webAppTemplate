using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Web;
using WebApp.Domain.Entities.Enums;

namespace WebApp.Domain.Entities.User
{
    public class User_Signin_Data
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime Crt_Usr { get; set; }
        public DateTime Last_Login { get; set; }
        public string IpAddress { get; set; }
        public LevelAccess Level { get; set; }
    }
}