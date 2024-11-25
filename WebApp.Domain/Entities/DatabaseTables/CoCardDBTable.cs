using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Domain.Entities.DatabaseTables
{
    public class CoCardDBTable
    {
        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }

        [Display(Name = "Image")]
        public byte[] img { get; set; }

        [Display(Name = "Pdf File")]
        public byte[] pdf_file { get; set; }
    }
}