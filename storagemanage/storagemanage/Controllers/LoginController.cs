using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HttpCommand;
using storagemanage.Models.common;
using QRCodeService;
using storagemanage.Models;

namespace storagemanage.Controllers
{
    public class LoginController : Controller
    {
        //api地址
        string url = System.Configuration.ConfigurationManager.ConnectionStrings["url"].ConnectionString;

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

        /*
         * 注册post处理
         */
        public ActionResult regPost()
        {
            string regUrl = url + "/api/Reg";
            string username = Request["username"];
            string password = Request["password"];
            string d = DateTime.Now.ToString();
            string sign = SignHelper.getRegSign(username, password, d);
            string requestParam = "username=" + username + "&password=" + password + "&d=" + d + "&sign=" + sign;
            string response = HttpPost.httppost(requestParam, regUrl);
            //var result = new { resultCode = response };
            LoginReg reg = JSONHelper.JsonDeserialize<LoginReg>(response);
            var result = new { code = reg.code, msg = reg.msg, returnCode = reg.returnCode };
            return Json(result, JsonRequestBehavior.AllowGet);
        }




        /*
         * api测试页面
         */
        public ActionResult Test()
        {
            return View();
        }

        /*
         * api测试
         */
        public ActionResult TestPost()
        {
            string res = HttpPost.httppost("pos=1&bill=1", "http://192.168.0.93:1000/api/Login");
            var result = new { res = res };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
