using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.Response;

namespace WebApp.BusinessLogic
{
    public class AdminSessionBL : AdminAPI, IAdminSessionBl
    {
        private readonly ApplicationDbContext _dbContext;

        public AdminSessionBL()
        {
            _dbContext = new ApplicationDbContext(); // Contextul bazei de date
        }

        // Preia toate anunțurile din baza de date
        public List<Announcement> GetAllAnnouncements()
        {
            return _dbContext.Announcements.ToList();
        }

        // Preia un anunț după ID
        public Announcement GetAnnouncementById(int id)
        {
            return _dbContext.Announcements.FirstOrDefault(a => a.Id == id);
        }

        // Adaugă un nou anunț
        public void AddAnnouncement(Announcement announcement)
        {
            if (announcement == null)
                throw new ArgumentNullException(nameof(announcement));

            _dbContext.Announcements.Add(announcement);
            _dbContext.SaveChanges();
        }

        // Șterge un anunț după ID
        public void DeleteAnnouncement(int id)
        {
            var announcement = _dbContext.Announcements.FirstOrDefault(a => a.Id == id);
            if (announcement == null)
                throw new KeyNotFoundException($"No announcement found with ID {id}");

            _dbContext.Announcements.Remove(announcement);
            _dbContext.SaveChanges();
        }
        public ActionStatus RegisterNewCard(CoCard card, HttpPostedFileBase photofile, HttpPostedFileBase pdffile)
        {
            return CreateCard(card, photofile, pdffile);

        }
    }
}
