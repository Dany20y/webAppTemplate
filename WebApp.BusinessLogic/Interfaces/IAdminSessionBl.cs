using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;

namespace WebApp.BusinessLogic.Interfaces
{
    public interface IAdminSessionBl
    {
        ActionStatus RegisterNewCard(CoCard card, HttpPostedFileBase photofile, HttpPostedFileBase pdffile);

    }
}
