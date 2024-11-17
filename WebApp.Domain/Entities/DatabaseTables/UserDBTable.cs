using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Security;
using System.Web;
using WebApp.Domain.Entities.Enums;

namespace WebApp.Domain.Entities.DatabaseTables
{
    public class UserDBTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        public string First_Name { get; set; }

        [Display(Name = "Last Name")]
        public string Last_Name { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name ="Creation User Time")]
        [DataType(DataType.Date)]
        public DateTime Crt_Usr { get; set; }

        [Required]
        [Display(Name ="Last Login Time")]
        [DataType(DataType.Date)]
        public DateTime Last_Login { get; set; }

        [Display(Name ="User IpAddress")]
        public string IpAddress { get; set; }

        [Required]
        [Display(Name="Level Access")]
        public LevelAccess Level { get; set; }
        
        [Display(Name = "User Photo")]
        public byte[] User_Photo { get; set; }
    }
}