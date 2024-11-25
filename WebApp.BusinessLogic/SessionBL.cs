using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.Response;
using WebApp.Domain.Entities.User;

namespace WebApp.BusinessLogic
{
    public class SessionBL : UserAPI, ISession
    {
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

        // Corectarea funcției GetCoCards pentru a implementa interfața ISession și pentru a mapa la CompCard
        public List<CoCard> CoCards
        {
            get
            {
                // Obținem cardurile din baza de date
                var dbCards = GetAllCardsFromDatabase();

                // Mapăm cardurile din tipul CoCardDBTable în tipul CompCard
                var compCards = dbCards.Select(card => new CoCard
                {
                    id = card.id,
                    title = card.title,           // Maparea Name la title
                    description = card.description,
                    img = card.img,        // Presupunem că există o proprietate `ImagePath` în CoCardDBTable
                    pdf_file = card.pdf_file  // Presupunem că există o proprietate `PdfFilePath` în CoCardDBTable
                }).ToList();

                return compCards;
            }
        }

        
    }
}
