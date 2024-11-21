﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class DocumentationController : Controller
    {
        // GET: Documentation
        private readonly ISession _session;

        public DocumentationController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session= bl.GetSession();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cards()
        {
            var userAPI = new UserAPI();
            var cards = userAPI.GetCoCards();

            if (cards == null || !cards.Any())
            {
                ViewBag.Message = "No cards available to display.";
                return View(new List<CompCard>()); // Trimite un model gol dacă nu există date
            }

            return View(cards); // Transmite modelul către view
        }



    }

}