using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

public class SessionExpireAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        // Check if the session exists
        if (HttpContext.Current.Session["UserID"] == null)
        {
            // Redirect to the login page
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(new { controller = "Login", action = "SignIn" })
            );
        }

        base.OnActionExecuting(filterContext);
    }
}
