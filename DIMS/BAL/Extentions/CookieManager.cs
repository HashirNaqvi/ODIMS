using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace DIMS.BAL.Extentions
{
    public class CookieManager
    {
        public static void SetCookie(string key, string value)
        {
            HttpCookie encodedCookie = new HttpCookie(key, value);
            if (HttpContext.Current.Request.Cookies[key] != null)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.AddHours(1);
                cookieOld.Value = encodedCookie.Value;
                HttpContext.Current.Response.Cookies.Add(cookieOld);
            }
            else
            {
                encodedCookie.Expires = DateTime.Now.AddHours(1);
                HttpContext.Current.Response.Cookies.Add(encodedCookie);
            }
        }
        public static string GetCookie(string key)
        {
            string value = string.Empty;
            HttpCookie cookie = HttpContext.Current.Request.Cookies[key];

            if (cookie != null)
            {
                // For security purpose, we need to encrypt the value.
                HttpCookie decodedCookie = cookie;
                value = decodedCookie.Value;
            }
            return value;
        }

        public static void ClearCookies()
        {
            string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string key in cookies)
            {
                var cookieOld = HttpContext.Current.Request.Cookies[key];
                cookieOld.Expires = DateTime.Now.AddHours(-1);
                cookieOld.Value = null;
                HttpContext.Current.Response.Cookies.Add(cookieOld);

            }
        }

    }
}