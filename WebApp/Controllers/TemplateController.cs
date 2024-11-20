using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class TemplateController : Controller
    {
        // GET: Template
        public ActionResult Index()
        {
            return View();
        }
    }
}