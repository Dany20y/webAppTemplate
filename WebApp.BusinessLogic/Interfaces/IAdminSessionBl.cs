using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;
using WebApp.Domain.Entities.DatabaseTables;

namespace WebApp.BusinessLogic.Interfaces
{
    public interface IAdminSessionBl
    {
        ActionStatus RegisterNewCard(CoCard card, HttpPostedFileBase photofile, HttpPostedFileBase pdffile);

        List<Announcement> GetAllAnnouncements(); // Metodă pentru a prelua toate anunțurile
        Announcement GetAnnouncementById(int id); // Metodă pentru a prelua un anunț specific
        void AddAnnouncement(Announcement announcement); // Metodă pentru a adăuga un nou anunț
        void DeleteAnnouncement(int id); // Metodă pentru a șterge un anunț după ID
    }
}
