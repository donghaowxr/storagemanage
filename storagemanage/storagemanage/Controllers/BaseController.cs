using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storagemanage.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Session["username"] == null)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Login");
            }
        }
    }
}
