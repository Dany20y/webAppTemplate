using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    [LoggedInFilter]
    public class AbbreviationController : Controller
    {
        // GET: Abbreviation
        public ActionResult Index()
        {
            return View();
        }
    }
}