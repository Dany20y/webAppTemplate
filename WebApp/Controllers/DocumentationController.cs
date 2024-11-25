using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
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
            _session = bl.GetSession();
        }

       

        [HttpGet]
        public ActionResult Index()
        {
            var cards = _session.GetCards();
            var viewModelCards = Mapper.Map<List<CompCard>>(cards);
            return View(viewModelCards);
        }

        public ActionResult DownloadPDF(int id)
        {
         
            var card = _session.GetCardById(id);

            if (card == null || card.pdf_file == null)
            {
                return HttpNotFound("The requested file does not exist.");
            }

            byte[] fileBytes = card.pdf_file;
            string fileName = $"{card.title}.pdf";

            return File(fileBytes, "application/pdf", fileName);
        }


    }
}
