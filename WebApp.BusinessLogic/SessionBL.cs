using System.Collections.Generic;
using System.Linq;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.Response;
using WebApp.Domain.Entities.User;

namespace WebApp.BusinessLogic
{
    public class SessionBL : UserAPI, ISession
    {
        private readonly ApplicationDbContext _context;
        public SessionBL()
        {
            _context = new ApplicationDbContext();
        }

        // Implementarea metodei GetAnnouncements din ISession
        public List<Announcement> GetAnnouncements()
        {
            return _context.Announcements.OrderByDescending(a => a.Date).ToList();
        }

        // Alte metode deja implementate
        public ActionStatus LoginUserStatus(User_Login_Data user)
        {
            return ULoginStatus(user);
        }

        public ActionStatus SigninUserStatus(User_Signin_Data user)
        {
            return USinginStatus(user);
        }

        public List<CoCard> GetCards() 
        {
            return GetAllCardsFromDatabase();
        }

        public CoCard GetCardById(int card)
        {
            return GetCardUsingId(card);
        }
        
    }
}
