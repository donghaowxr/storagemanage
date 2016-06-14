using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace storagemanageapi.Models
{
    public class Users
    {
        /*
         * id
         */
        public int id
        {
            get;
            set;
        }

        /*
         * 用户名
         */
        public string username
        {
            get;
            set;
        }

        /*
         * 密码
         */
        public string password
        {
            get;
            set;
        }

        /*
         * 手机号
         */
        public string phone
        {
            get;
            set;
        }

        /*
         * 电话
         */
        public string tel
        {
            get;
            set;
        }

        /*
         * 登录状态
         */
        public int state
        {
            get;
            set;
        }

        /*
         * 用户角色
         */
        public int iden
        {
            get;
            set;
        }

        /*
         * 注册时间
         */
        public string regTime
        {
            get;
            set;
        }
    }
}