using swiftpass.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace storagemanageapi.Models.common
{
    public class GetSignHelper
    {
        public static string getSignHelper(string[] strs)
        {
            Array.Sort(strs);
            string str = string.Join("&", strs);
            string sign = MD5Util.GetMD5(str, "UTF-8");
            return sign;
        }

        /*
         * 获取注册sign签名
         */
        public static string getRegSign(string username, string password, string d, string iden)
        {
            string[] strs = { "username=" + username, "password=" + password, "d=" + d, "iden=" + iden };
            return getSignHelper(strs);
        }

        /*
         * 获取登录sign签名
         */
        internal static string getLoginSign(string username, string password, string d)
        {
            string[] strs = { "username=" + username, "password=" + password, "d=" + d };
            return getSignHelper(strs);
        }
    }
}