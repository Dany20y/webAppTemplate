using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
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
            try
            {
                UserDBTable userRecord;

                // Verify user existence
                using (var db = new UserContext())
                {
                    userRecord = db.Users_Table.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                    if (userRecord == null)
                    {
                        return new ActionStatus
                        {
                            IsSuccess = false,
                            StatusMessage = "Invalid email or password.",
                            SessionKey = ""
                        };
                    }
                }

                // Check if the user is an admin (or any other role you need to check)
                bool isAdmin = userRecord.Level == LevelAccess.ADMIN; // Replace LevelAccess.ADMIN with your actual enum value or role check

                // Update last login timestamp
                using (var db = new UserContext())
                {
                    userRecord.Last_Login = DateTime.Now;
                    db.Entry(userRecord).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                // Create a session for the user
                string sessionKey = CreateSession(userRecord.UserId);

                // Return successful response with session key and user role
                return new ActionStatus
                {
                    IsSuccess = true,
                    StatusMessage = "Login successful.",
                    SessionKey = sessionKey,
                    IsAdmin = isAdmin,
                };
            }
            catch (Exception ex)
            {
                // Log exception (you can use a logger here)
                return new ActionStatus
                {
                    IsSuccess = false,
                    StatusMessage = $"An error occurred during login: {ex.Message}",
                    SessionKey = ""
                };
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            // Use a proper hashing and verification method (e.g., BCrypt, PBKDF2)
            // Here we are using a placeholder comparison for simplicity
            return enteredPassword == storedPasswordHash;
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
                id = card.id,  
                title = card.title,
                description = card.description,
                img = card.img,
                pdf_file = card.pdf_file,
            }).ToList();

            return compCards;
        }


        public List<CoCard> GetAllCardsFromDatabase()
        {
            using (var context = new CardContext())
            {
               
                    var cards = context.Cards.ToList();
                    var CoCards = Mapper.Map<List<CoCard>>(cards);
                    return CoCards;
            }
        }

        internal string CreateSession(int userId)
        {
            try
            {
                using (var db = new UserContext())
                {
                    // Create a new session
                    var newSession = new SessionDBTable
                    {
                        UserId = userId,
                        Cookie_Name = Guid.NewGuid().ToString(),
                        Cookie_Expiration = DateTime.Now.AddDays(1), // Cookie expires in 1 day
                        Cookie_SecurePolicy = true,
                        Cookie_HttpOnly = true,
                        Cookie_IsEssential = false,
                        Cookie_Path = "/",
                        Cookie_Domain = "yourdomain.com"
                    };

                    db.Session_Table.Add(newSession);
                    db.SaveChanges();

                    return newSession.Cookie_Name;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create session", ex);
            }
        }



    }
}




