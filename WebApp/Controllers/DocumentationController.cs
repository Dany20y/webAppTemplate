using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;

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
            // Preia toate cardurile din baza de date
            var cards = _session.GetCoCards();
            return View(cards);
        }

    }

}