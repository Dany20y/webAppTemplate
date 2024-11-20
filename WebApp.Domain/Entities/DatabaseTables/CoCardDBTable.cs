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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id;

        [Required]
        [Display(Name = "Title")]
        public string title;

        [Display(Name = "Description")]
        public string description;

        [Display(Name = "Image")]
        public byte[] img;

        [Display(Name = "Pdf File")]
        public byte[] pdf_file;
    }
}