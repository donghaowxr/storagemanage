using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace HttpCommand
{
    public class HttpPost
    {
        public static string url;
        public static string postStr;


        public delegate void Write(string msg);
        public Write write;


        /// <summary>
        /// post方法
        /// </summary>
        /// <param name="requestParam">post参数</param>
        /// <param name="url">post url</param>
        /// <returns>返回成功信息，失败返回failure</returns>
        public static string httppost(string requestParam, string url)
        {
            try
            {
                byte[] bs = Encoding.UTF8.GetBytes(requestParam);
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = bs.Length;
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(bs, 0, bs.Length);
                }

                
                Console.WriteLine("POST:" + url+" DATA:" + requestParam);
                //WLOG.writeLog("POST:" + url + " DATA:" + requestParam);
                //WLOG.writeControlLog("POST:" + url + " DATA:" + requestParam, WLOG.FormText, 3);
               
                //Console.WriteLine("DATA:" + requestParam);
                try
                {
                    HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                    if (Convert.ToInt32(res.StatusCode) == 200)
                    {
                        Stream resStream = res.GetResponseStream();
                        StreamReader sr = new StreamReader(resStream, Encoding.GetEncoding("UTF-8"));
                        string reqstring = sr.ReadToEnd();
                        sr.Close();
                        resStream.Close();
                        //WLOG.writeLog("BACK:" + url + " DATA:" + reqstring);
                        //WLOG.writeControlLog("BACK:" + url + " DATA:" + reqstring, WLOG.FormText, 4);
                        return reqstring;
                    }
                    else
                    {
                        return "failure";
                    }
                }
                catch (WebException ex)
                {
                    return "failure:" + ex.ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
    }
}
