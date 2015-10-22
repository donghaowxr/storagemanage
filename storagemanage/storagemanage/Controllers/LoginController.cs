using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storagemanage.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        /*
         * 登录action
         */
        public ActionResult Login()
        {
            return View();
        }

    }
}
