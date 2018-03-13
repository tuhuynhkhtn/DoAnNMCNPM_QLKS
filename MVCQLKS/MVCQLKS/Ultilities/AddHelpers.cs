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
        public static string GetUserName(this HtmlHelper html)
        {
            var ui = HttpContext.Current.Session["Logged"] as UserInfo;
            if (ui != null)
            {
                return ui.UserName;
            }
            return "";
        }

        public static MvcHtmlString LessString(this HtmlHelper html, string str, int maxLength)
        {
            if (str.Length < maxLength)
            {
                return new MvcHtmlString(str);
            }
            return new MvcHtmlString(
                string.Format("{0}...", str.Substring(0, maxLength - 3)));
        }

        public static string Price2String(this HtmlHelper html, decimal price)
        {
            return string.Format("{0:N0} đ", price);
        }

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

        public static bool IsLoggedAdmin(this HtmlHelper html)
        {
            if (HttpContext.Current.Request.Cookies["UserId"] != null)
            {
                int id = int.Parse(HttpContext.Current.Request.Cookies["UserId"].Value);
                using (var dc = new QLKSEntities())
                {
                    var user = dc.Users.Where(u => u.f_ID == id && u.f_Permission == 1).FirstOrDefault();
                    if (user != null)
                    {
                        HttpContext.Current.Session["Logged"] = new UserInfo { UserName = user.f_UserName };
                        return true;
                    }
                }
            }
            return false;
        }

    }