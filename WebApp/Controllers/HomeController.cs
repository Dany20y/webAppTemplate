using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApp.Domain;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        // Afișează pagina pentru administrarea anunțurilor
        public ActionResult AddAnnouncements()
        {
            var announcements = _context.Announcements
                .OrderByDescending(a => a.Date)
                .ToList();

            var viewModel = Mapper.Map<List<Announcement>, List<CompAnnouncement>>(announcements);

            return View(viewModel); // Trimite lista de anunțuri către view
        }

        // Adaugă un anunț nou
        [HttpPost]
        public ActionResult AddAnnouncement(CompAnnouncement announcement)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("AddAnnouncements");

            var dbAnnouncement = Mapper.Map<CompAnnouncement, Announcement>(announcement);
            dbAnnouncement.Date = DateTime.Now; // Setează data curentă

            _context.Announcements.Add(dbAnnouncement);
            _context.SaveChanges();

            TempData["Success"] = "Anunț adăugat cu succes!";
            return RedirectToAction("AddAnnouncements");
        }

        // Șterge un anunț
        [HttpPost]
        public ActionResult DeleteAnnouncement(int id)
        {
            var announcement = _context.Announcements.SingleOrDefault(a => a.Id == id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
                TempData["Success"] = "Anunț șters cu succes!";
            }
            else
            {
                TempData["Error"] = "Anunțul nu a fost găsit!";
            }

            return RedirectToAction("AddAnnouncements");
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}
