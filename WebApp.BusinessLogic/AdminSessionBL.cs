using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;

namespace WebApp.BusinessLogic
{
    public class AdminSessionBL : AdminAPI, IAdminSessionBl
    {
        public ActionStatus RegisterNewCard(CoCard card, HttpPostedFileBase photofile, HttpPostedFileBase pdffile)
        {
            return CreateCard(card, photofile, pdffile);

        }
    }
}