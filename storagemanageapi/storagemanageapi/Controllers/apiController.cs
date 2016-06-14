using SchoolMateCommon;
using storagemanageapi.Models;
using storagemanageapi.Models.common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace storagemanageapi.Controllers
{
    public class apiController : Controller
    {
        //数据库连接字符串
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RegTest()
        {
            return View();
        }

        /*
         * 用户注册
         */
        [HttpPost]
        public ActionResult Reg()
        {
            string username = Request["username"];
            string password = Request["password"];
            string d = Request["d"];
            string iden = Request["iden"];
            string sign = Request["sign"];
            string regSign = GetSignHelper.getRegSign(username, password, d, iden);
            if (sign == regSign)
            {
                int count=0;
                SqlParameter[] userParams = { new SqlParameter("@username", username), new SqlParameter("@count", count) };
                userParams[1].Direction = ParameterDirection.Output;
                try
                {
                    SQLHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "SamUser_proc", userParams);
                    count = Convert.ToInt32(userParams[1].Value);
                    if (count > 0)
                    {
                        var result = new { code = "1", msg = "FAIL", returnCode = "user exist" };
                        return Json(result, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        SqlParameter[] regParams = { new SqlParameter("@username", username), new SqlParameter("@password", password), new SqlParameter("@iden", iden), new SqlParameter("@regTime", d) };
                        var regMsg = SQLHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "reg_proc", regParams);
                        if (regMsg > 0)
                        {
                            //注册成功返回
                            var result = new { code = "0", msg = "SUCCESS", returnCode = "reg ok" };
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            //数据库错误返回
                            var result = new { code = "2", msg = "FAIL", returnCode = "data error" };
                            return Json(result, JsonRequestBehavior.AllowGet);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    var result = new { code = "2", msg = "FAIL", returnCode = "data error" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                //签名错误返回
                var result = new { code = "10", msg = "FAIL", returnCode = "sign error" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        /*
         * 用户登录
         */
        [HttpPost]
        public ActionResult Login()
        {
            string username = Request["username"];
            string password = Request["password"];
            string d = Request["d"];
            string sign = Request["sign"];
            string loginSign = GetSignHelper.getLoginSign(username, password, d);
            if (sign == loginSign)
            {
                SqlParameter[] loginParams = { new SqlParameter("@username", username), new SqlParameter("@password", password) };
                var dataTable = SQLHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "loginUsername_proc", loginParams);
                if (dataTable.Tables[0].Rows.Count > 0)
                {
                    Users user = new Users();
                    user.username = dataTable.Tables[0].Rows[0]["username"].ToString();
                    user.iden = Convert.ToInt32(dataTable.Tables[0].Rows[0]["iden"]);
                    user.regTime = dataTable.Tables[0].Rows[0]["regTime"].ToString();
                    var result = new { code = "0", msg = "SUCCESS", returnCode = "login success", user = user };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var result = new { code = "3", msg = "FAIL", returnCode = "login fail" };
                    return Json(result, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var result = new { code = "1", msg = "FAIL", returnCode = "sign error" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Testapi()
        {
            string username = Request["username"];
            string password = "123456";
            SqlParameter[] pars = { new SqlParameter("@username", username), new SqlParameter("@password", password) };
            var clientds = SQLHelper.ExecuteDataset(connStr, CommandType.StoredProcedure, "loginUsername_proc", pars);
            if (clientds.Tables[0].Rows.Count > 0)
            {

            }

            int count = 0;
            //SqlParameter[] pars = { new SqlParameter("@username", username), new SqlParameter("@count", count) };
            //pars[1].Direction = ParameterDirection.Output;
            //int res= SQLHelper.ExecuteNonQuery(connStr, CommandType.StoredProcedure, "loginUsername_proc", pars);
            //count = Convert.ToInt32(pars[1].Value);
            var result = new { count = count };
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
