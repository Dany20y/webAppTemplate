using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Filters;

namespace WebApp.Controllers
{
    public class UpdatesController : Controller
    {
        // GET: Updates
        [LoggedInFilter]
        public ActionResult Index()
        {
            var userProfile = HttpContext.Session["UserProfile"];
            if (userProfile == null || !(bool)((dynamic)userProfile).IsAdmin)
            {
                return RedirectToAction("Index", "LogIn");
            }

            return View();
        }
    }
}