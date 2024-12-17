using System;
using System.Web;
using System.Web.Mvc;
using WebApp.Domain.Entities.Enums;

namespace WebApp.Filters
{
    public class LoggedInFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userProfile = HttpContext.Current.Session["UserProfile"];

            if (userProfile == null)
            {
                // Redirect to the login page if user profile is not found in the session
                filterContext.Result = new RedirectResult("~/LogIn/Index");
                return;
            }

            dynamic profile = userProfile;

            // Check if the user's level access is "user" and allow access
            if (profile.IsAdmin == false)
            {
                // Allow access to the action
                base.OnActionExecuting(filterContext);
            }
            else
            {
                // Optionally, you can redirect or show an error message if the user is not authorized
                base.OnActionExecuting(filterContext);
                
            }
        }
    }
}
