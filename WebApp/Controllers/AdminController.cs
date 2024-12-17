using AutoMapper;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    [AdminLevelFilter]
    public class AdminController : Controller
    {
        private readonly IAdminSessionBl _adminSession;

        public AdminController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _adminSession = bl.GetAdminSession();
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
        public ActionResult AddDocumentation(CompCard cardData)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase photofile = Request.Files["photofile"];
                HttpPostedFileBase pdffile = Request.Files["pdffile"];

                var new_card = Mapper.Map<CoCard>(cardData);
                ActionStatus resp = _adminSession.RegisterNewCard(new_card, photofile, pdffile);

                if (resp.IsSuccess)
                {
                    ViewBag.Message = resp.StatusMessage;
                    return View();
                }
                else
                {
                    ViewBag.Message = resp.StatusMessage;
                    return View(cardData);
                }
            }
            return View(cardData);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUpdated(UpdateCardM cardInfo)
        {
            if (ModelState.IsValid)
            {

                var new_card = Mapper.Map<UpdateCard>(cardInfo);
                ActionStatus resp = _adminSession.CreateNewUpdate(new_card);

                if (resp.IsSuccess)
                {
                    ViewBag.Message = resp.StatusMessage;
                    return View();
                }
                else
                {
                    ViewBag.StatusMessage = resp.StatusMessage;
                    return View(cardInfo);
                }
            }
            return View(cardInfo);
        }

    }
}
