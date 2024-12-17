using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Domain.Entities.User;

namespace WebApp.Domain.Entities.DatabaseTables
{
    public class SessionDBTable
    {
        [Key]
        public string SessionId { get; set; } = Guid.NewGuid().ToString();

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual UserDBTable User { get; set; }

        
        public string Cookie_Name { get; set; }
        public DateTime Cookie_Expiration { get; set; }
        public bool Cookie_SecurePolicy { get; set; }
        public bool Cookie_HttpOnly { get; set; }
        public string Cookie_Path { get; set; }
        public string Cookie_Domain { get; set; }
        public bool Cookie_IsEssential { get; set; }
        public bool Cookie_SameSite { get; set; }
    }
}
