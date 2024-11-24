using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApp.BusinessLogic.DBModel;
using WebApp.Domain.Entities.Comp;
using WebApp.Domain.Entities.DatabaseTables;
using WebApp.Domain.Entities.Enums;
using WebApp.Domain.Entities.Response;
using WebApp.Domain.Entities.User;

namespace WebApp.BusinessLogic.Core
{
    public class UserAPI
    {
        public ActionStatus ULoginStatus(User_Login_Data user)
        {
            //TO DO: add the log in method, documetn yourself on the
            //google api and twiter api to make the autheification
            UserDBTable table;
            using (var db = new UserContext())
            {
                table = db.Users_Table.FirstOrDefault(u => u.Email == user.Email);
            }
            if (table.Email != null && table.Password == user.Password)
            {
                using (var todo = new UserContext())
                {
                    table.Last_Login = DateTime.Now;
                    todo.Entry(table).State = System.Data.Entity.EntityState.Modified;
                    todo.SaveChanges();
                };
                return new ActionStatus { IsSuccess = true, StatusMessage = "200 OK", SessionKey = "" };
            }
            else
            {
                return new ActionStatus
                {
                    IsSuccess = false,
                    StatusMessage = "No users found with this email!",
                    SessionKey = "",
                };
            }
        }

        public ActionStatus USinginStatus(User_Signin_Data user)
        {
            try
            {
                using (var db = new UserContext())
                {
                    bool emaiExists = db.Users_Table.Any(e => e.Email == user.Email);
                    bool usernameExists = db.Users_Table.Any(u => u.Username == user.Username);
                    if (emaiExists)
                    {
                        return new ActionStatus
                        {
                            IsSuccess = false,
                            StatusMessage = "There is already a user with this email",
                            SessionKey = "",
                        };
                    }
                    else if (usernameExists)
                    {
                        return new ActionStatus
                        {
                            IsSuccess = false,
                            StatusMessage = "there is already a  user with this email",
                            SessionKey = "",
                        };
                    }
                }

                var new_user = Mapper.Map<UserDBTable>(user);
                new_user.IpAddress = "170.206.134.144";
                new_user.Level = LevelAccess.USER;
                new_user.Crt_Usr = DateTime.Now;
                new_user.Last_Login = DateTime.Now;

                using (var db = new UserContext())
                {
                    db.Users_Table.Add(new_user);
                    db.SaveChanges();
                }
                return new ActionStatus { IsSuccess = true, StatusMessage = "200 OK", SessionKey = "" };
            }
            catch (Exception ex)
            {
                return new ActionStatus { IsSuccess = false, StatusMessage = $"An error occurred: {ex.Message}", SessionKey = "" };
            }

        }


        public List<CoCard> GetCoCards()
        {
            var dbCards = GetAllCardsFromDatabase();

            // Mapează cardurile din CoCardDBTable la CompCard
            var compCards = dbCards.Select(card => new CoCard
            {
                id = card.id,  // Folosește numele corect, așa cum este definit în CoCardDBTable
                title = card.title,
                description = card.description,
                img = card.img,
                pdf_file = card.pdf_file
            }).ToList();

            return compCards;
        }


        public List<CoCardDBTable> GetAllCardsFromDatabase()
    {
        using (var context = new CardContext())
        {
            try
            {
                var cards = context.Cards.ToList();
                Console.WriteLine($"Number of cards fetched from database: {cards.Count}");
                return cards;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching cards: {ex.Message}");
                return new List<CoCardDBTable>();
            }
        }
    }


}
}



