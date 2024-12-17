using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Domain.Entities.Comp
{
    public class UpdateCard
    {
        public int UpdateId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Author_name { get; set; }
        public string Moodification_name { get; set; }
    }
}