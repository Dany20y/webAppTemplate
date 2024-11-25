using System;

namespace WebApp.Domain.Entities.Comp
{
    public class CoAnnouncements
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
