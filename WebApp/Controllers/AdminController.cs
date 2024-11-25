using AutoMapper;
using System;
using System.Linq;
using System.Web.Mvc;
using WebApp.BusinessLogic;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;
using WebApp.Models;
using WebApp.Domain;
using System.Web;

namespace WebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminSessionBl _adminSession;

        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _adminSession = bl.GetAdminSession() ;
        }

        // GET: Admin
        private ApplicationDbContext _context = new ApplicationDbContext();

        public ActionResult Index()
        {
            var announcements = _context.Announcements.OrderByDescending(a => a.Date).ToList();
            return View(announcements);
        }

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

            return RedirectToAction("Index");
        }

        public ActionResult AddAbbreviation()
        {
            return View();
        }

        public ActionResult AddDocumentation()
        {
            return View();
        }
        public ActionResult AddTemplate()
        {
            return View();
        }

        public ActionResult AddUpdates()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDocumentation(CompCard cardData) {
            HttpPostedFileBase photofile = Request.Files["photofile"];
            HttpPostedFileBase pdffile = Request.Files["pdffile"];

            if (ModelState.IsValid) { 
                var new_card = Mapper.Map<CoCard>(cardData);
                ActionStatus resp = _adminSession.RegisterNewCard(new_card, photofile, pdffile);

                if (resp.IsSuccess)
                {
                    ViewBag.Message = resp.StatusMessage;
                    return RedirectToAction("AddDocumentation", "Admin");
                }
                else
                {
                    ViewBag.Message = resp.StatusMessage;
                    return View(cardData);
                }
            }
            return View(cardData);
        }

       
    }
}
