using System;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Filters
{
    public class AdminLevelFilter : ActionFilterAttribute
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

            if (profile.IsAdmin == false)
            {
                // Redirect to the login page or another page if the user is not an admin
                filterContext.Result = new RedirectResult("~/LogIn/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
