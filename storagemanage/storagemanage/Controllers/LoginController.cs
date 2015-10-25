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
            ViewData["url"] = url;
            return View();
        }

        string url = System.Configuration.ConfigurationManager.ConnectionStrings["url"].ConnectionString;
        /*
         * 获取url测试
         */
        public ActionResult GetUrl()
        {
            var result = new { url = url };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
