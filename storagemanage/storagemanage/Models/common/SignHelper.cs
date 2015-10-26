using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using swiftpass.utils;

namespace storagemanage.Models.common
{
    public class SignHelper
    {
        public static string signHelper(string[] strs)
        {
            Array.Sort(strs);
            string str = string.Join("&", strs);
            string sign = MD5Util.GetMD5(str, "UTF-8");
            return sign;
        }

        /*
         * 获取注册签名
         */
        public static string getRegSign(string username, string password, string d)
        {
            string[] strs = { "username=" + username, "password=" + password, "d=" + d };
            return signHelper(strs);
        }
    }
}