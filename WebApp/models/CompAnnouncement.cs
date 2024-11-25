using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Models;

namespace WebApp.Models
{
    public class CompAnnouncement
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string DateCreated { get; set; } // Formatare pentru afișare
        public bool IsActive { get; set; }
    }
}

