using App.Models;
using AutoMapper;
using System;
using System.Web.Mvc;
using WebApp.BusinessLogic;
using WebApp.BusinessLogic.Core;
using WebApp.BusinessLogic.Interfaces;
using WebApp.Domain.Entities.Enums;
using WebApp.Domain.Entities.User;

namespace WebApp.Controllers
{
    public class LogInController : Controller
    {
        private readonly ISession _session;

        // Constructor for dependency injection (optional)
        public LogInController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _session = bl.GetSession();

        }

        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LogInUser user)
        {
            if (user == null || string.IsNullOrEmpty(user.Email) || string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("", "Invalid login details. Please try again.");
                return View(user);
            }

            // Authenticate user using the UserAPI
            var new_user = Mapper.Map<User_Login_Data>(user);
            var loginResponse = _session.LoginUserStatus(new_user);

            if (loginResponse.IsSuccess)
            {
                
                if (loginResponse.IsAdmin)                  {
                    HttpContext.Session["UserProfile"] = new
                    {
                        Email = user.Email,
                        SessionKey = loginResponse.SessionKey,
                        IsAdmin = true
                    };
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    // Regular user session
                    HttpContext.Session["UserProfile"] = new
                    {
                        Email = user.Email,
                        SessionKey = loginResponse.SessionKey,
                        IsAdmin = false
                    };

                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Add error message to ModelState
                ModelState.AddModelError("", loginResponse.StatusMessage);
                return View(user);
            }
        }

        // Optional: LogOut action to clear session
        public ActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
