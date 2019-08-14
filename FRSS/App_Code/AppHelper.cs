using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FRSS.App_Code
{
    public static class AppHelper
    {
        public static void AddToSession(this object data, string key)
        {
            HttpContext.Current.Session.Add(key, data);
        }

        public static object GetFromSession(this string key)
        {
            return HttpContext.Current.Session[key];
        }

        public static void LogOut()
        {
            HttpContext.Current.Session.Abandon();
            FormsAuthentication.SignOut();
        }
    }
}