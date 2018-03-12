using System.Web.Mvc;
using MVCQLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCQLKS.Ultilities
{
    public static class AddHelpers
    {
        public static object HtttpContext { get; private set; }

        public static bool IsLogged(this HtmlHelper html)
        {
            if (HttpContext.Current.Session["Logged"] == null)
            {
                if (HttpContext.Current.Request.Cookies["UserId"] != null)
                {
                    int id = int.Parse(HttpContext.Current.Request.Cookies["UserId"].Value);
                    using (var dc = new QLKSEntities())
                    {
                        var user = dc.Users.Where(u => u.f_ID == id).FirstOrDefault();
                        if (user != null)
                        {
                            HttpContext.Current.Session["Logged"] = new UserInfo { UserName = user.f_UserName };
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        public static string GetUserName(this HtmlHelper html)
        {
            var ui = HttpContext.Current.Session["Logged"] as UserInfo;
            if (ui != null)
            {
                return ui.UserName;
            }
            return "";
        }
    }
}