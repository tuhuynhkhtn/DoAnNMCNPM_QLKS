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

        public static bool RoomAdmin = true;
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

        public static string GetUserName(this HtmlHelper html)
        {
            var ui = HttpContext.Current.Session["Logged"] as UserInfo;
            if (ui != null)
            {
                return ui.UserName;
            }
            return "";
        }

        public static bool CheckEmpty(UserRegisting Reg)
        {
            if (Reg.UserName == null || Reg.Password == null || Reg.ConfirmPassword == null || Reg.CaptchaCode == null)
            {
                return true;
            }
            return false;
        }

        //Check username exist
        public static bool UserNameExist(string Username)
        {
            using (var dc = new QLKSEntities())
            {
                var _username = dc.Users.Where(u => u.f_UserName == Username).FirstOrDefault();

                if (_username != null)
                {
                    return true;
                }
            }
            return false;
        }

        public static RegisterError GetErrorNullRegisting(UserRegisting Reg)
        {
            //Empty
            if (CheckEmpty(Reg) == true)
            {
                RegisterError reErr = new RegisterError();
                if (Reg.UserName == null)
                {
                    reErr.ErrorUserName = "Bạn cần nhập UserName!";
                }
                else if (Reg.UserName != null)
                {
                    bool b = UserNameExist(Reg.UserName);
                    if (b == true)
                    {
                        reErr.ErrorUserName = "UserName đã tồn tại!";
                    }
                }

                if (Reg.Password == null)
                {
                    reErr.ErrorPassword = "Bạn cần nhập Mật khẩu!";
                }

                if (Reg.ConfirmPassword == null)
                {
                    reErr.ErrorConfirmPassword = "Nhập lại Mật khẩu!";
                }

                else if (Reg.ConfirmPassword != null && Reg.Password != null)
                {
                    if (Reg.ConfirmPassword != Reg.Password)
                    {
                        reErr.ErrorConfirmPassword = "Nhập lại không đúng!";
                    }
                }

                if (Reg.Name == null)
                {
                    reErr.ErrorName = "Bạn cần nhập Họ tên!";
                }

                if (Reg.CaptchaCode == null)
                {
                    reErr.ErrorCaptcha = "Bạn cần nhập Captcha để xác nhận!";
                }
                return reErr;
            }
            else
            {
                return null;
            }
        }

        public static UserInfo GetUserInfo(this HtmlHelper html)
        {
            var ui = HttpContext.Current.Session["Logged"] as UserInfo;
            return ui;
        }

        public static IList<SelectListItem> GetSLICat(this HtmlHelper html)
        {
            var l = new List<SelectListItem>();
            using (var dc = new QLKSEntities())
            {
                foreach (var c in dc.Categories.ToList())
                {
                    l.Add(new SelectListItem
                    {
                        Value = c.CatID.ToString(),
                        Text = c.CatName
                    });
                }
            }
            return l;
        }

        public static string GetCatName(this HtmlHelper html, int id)
        {
            var name = "";
            using (var dc = new QLKSEntities())
            {
                var cat = dc.Categories.Where(c => c.CatID == id).FirstOrDefault();
                if(cat != null)
                {
                    name = cat.CatName;
                    return name;
                }
            }
            return name;
        }

        public static decimal GetCatPrice(this HtmlHelper html, int catId)
        {
            decimal gia = 0;
            using (var dc = new QLKSEntities())
            {
                var cat = dc.Categories.Where(c => c.CatID == catId).FirstOrDefault();
                if (cat != null)
                {
                    gia = cat.Price;
                    return gia;
                }
            }
            return gia;
        }

        //public static string GetUserName(this HtmlHelper html)
        //{
        //    var ui = HttpContext.Current.Session["Logged"] as UserInfo;
        //    if (ui != null)
        //    {
        //        return ui.UserName;
        //    }
        //    return "";
        //}

        public static string GetCusTypeName(this HtmlHelper html, int id)
        {
            string name = "";
            using (var dc = new QLKSEntities())
            {
                var ct = dc.CusTypes.Where(c => c.CusTypeID == id).FirstOrDefault();
                if (ct != null)
                {
                    name = ct.CusTypeName;
                    return name;
                }
            }
            return name;
        }

        public static string GetRoomName(this HtmlHelper html, int id)
        {
            string name = "";
            using (var dc = new QLKSEntities())
            {
                var r = dc.Rooms.Where(c => c.RoomID == id).FirstOrDefault();
                if (r != null)
                {
                    name = r.RoomName;
                    return name;
                }
            }
            return name;
        }

        public static IList<SelectListItem> GetSLICusType(this HtmlHelper html)
        {
            var l = new List<SelectListItem>();
            using (var dc = new QLKSEntities())
            {
                foreach (var c in dc.CusTypes.ToList())
                {
                    l.Add(new SelectListItem
                    {
                        Value = c.CusTypeID.ToString(),
                        Text = c.CusTypeName
                    });
                }
            }
            return l;
        }

        public static IList<SelectListItem> GetSLIRoom(this HtmlHelper html)
        {
            var l = new List<SelectListItem>();
            using (var dc = new QLKSEntities())
            {
                foreach (var c in dc.Rooms.ToList())
                {
                    l.Add(new SelectListItem
                    {
                        Value = c.RoomID.ToString(),
                        Text = c.RoomName
                    });
                }
            }
            return l;
        }
    }
}