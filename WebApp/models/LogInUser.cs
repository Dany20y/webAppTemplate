using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Domain.Entities.Enums;

namespace App.Models
{
    public class LogInUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public LevelAccess Level { get; set; }
    }
}
