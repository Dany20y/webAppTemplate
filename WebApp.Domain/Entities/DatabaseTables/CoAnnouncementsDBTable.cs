using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Domain.Entities.DatabaseTables
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string Message { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
