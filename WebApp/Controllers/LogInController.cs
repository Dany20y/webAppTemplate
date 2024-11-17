using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.SessionState;
using WebApp.BusinessLogic;
using WebApp.BusinessLogic.Interfaces;

namespace WebApp.Controllers
{
    public class LogInController : Controller
    {
        /*private readonly ISession _session;*/

        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

    /*    [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LogInUser user)
        {
            HttpContext.Session["UserProfile"] = user;
            
            if (_sessionState == null)
            {
                return RedirectToAction("Index");
            }
            
            return RedirectToAction("Index");
        }*/
    }
}