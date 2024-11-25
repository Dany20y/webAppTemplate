using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CompCard
    {
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public byte[] img { get; set; }
        public byte[] pdf_file { get; set; }
    }
}