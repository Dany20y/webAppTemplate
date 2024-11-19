using AutoMapper;
using System.Web.Mvc;
using WebApp.BusinessLogic.Interfaces;
using WebApp.BusinessLogic;
using WebApp.Domain.Entities.User;
using WebApp.Models;

public class SignInController : Controller
{ 
    private readonly ISession _session;

    public SignInController()
    {
        var bl = new BusinessLogic();
        _session = bl.GetSession();
    }

    public ActionResult Index()
    {
        // Passing an empty model to the view
        return View(new SingInUser());
    }


    [HttpPost]
    public ActionResult Index(SingInUser user)
    {
        if (ModelState.IsValid)
        {
            var new_user = Mapper.Map<User_Signin_Data>(user);

            var registerUser = _session.SigninUserStatus(new_user);
            if (registerUser.IsSuccess)
            {
                ViewBag.SuccessMessage = registerUser.ToString();
                return RedirectToAction("Index", "LogIn");
            }
            else
            {
                ViewBag.ErrorMessage = registerUser.StatusMessage;
            }
        }
        return View(user);
    }
}
