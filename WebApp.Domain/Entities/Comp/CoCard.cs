using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace WebApp.Domain.Entities.Comp
{
    public class CoCard
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public byte[] img { get; set; }
        public byte[] pdf_file { get; set; }
    }
}