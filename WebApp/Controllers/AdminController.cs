using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;
using WebApp.Models;

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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddDocumentation()
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