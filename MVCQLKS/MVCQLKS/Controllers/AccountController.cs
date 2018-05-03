using BotDetect.Web.Mvc;
using MVCQLKS.Models;
using MVCQLKS.Ultilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCQLKS.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Account/Login
        [HttpPost]

        public ActionResult Login(UserInfo ui)
        {
            var pass = Ulti.Md5Hash(ui.Password);
            using (var dc = new QLKSEntities())
            {
                var user = dc.Users.Where(u => u.f_UserName == ui.UserName && u.f_Password == pass).FirstOrDefault();
                if (user != null)
                {
                    ui.Permission = user.f_Permission;
                    ui.UserID = user.f_ID;
                    Session["Logged"] = ui;
                    Response.Cookies["UserId"].Value = user.f_ID.ToString();
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(7);

                    if (ui.Permission == 1)
                    {
                        return RedirectToAction("IndexManageRoom", "ManageRoom");
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMsg = "Thông tin đăng nhập chưa đúng!";
                }
            }
            return View();
        }

        //POST: Account/Logout
        [HttpPost]
        public ActionResult Logout()
        {
            Session["Logged"] = null;
            Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(-1);

            return RedirectToAction("Login", "Account");
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]

        public ActionResult Register(UserRegisting user)
        {
            if (!ModelState.IsValid)
            {
                // TODO: Captcha validation failed, show error message
                ViewBag.ErrorMsg = "Captcha không hợp lệ!";
            }
            else
            {
                using (var dc = new QLKSEntities())
                {
                    var userTonTai = dc.Users.Where(us => us.f_UserName == user.UserName).FirstOrDefault();
                    if (userTonTai != null)
                    {
                        ViewBag.ErrorMsg = "Tên đăng nhập đã tồn tại!";
                    }
                    else
                    {
                        var u = new User
                        {
                            f_UserName = user.UserName,
                            f_Password = Ulti.Md5Hash(user.Password),
                            f_Name = user.Name
                        };
                        dc.Users.Add(u);
                        dc.SaveChanges();

                        var ui = new UserInfo { UserName = u.f_UserName };
                        Session["Logged"] = ui;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View();
        }

        [AuthActionFilter]

        public ActionResult Profile()
        {
            var ui = Session["Logged"] as UserInfo;
            using (var dc = new QLKSEntities())
            {
                var u = dc.Users.Where(m => m.f_Name == ui.UserName).FirstOrDefault();
                if (u != null)
                {
                    var a = new UserInfo
                    {
                        UserID = u.f_ID,
                        UserName = u.f_Name,
                        Name = u.f_Name,
                    };
                    return View(a);
                }
                return View(ui);
            }
        }

        [HttpPost]
        public ActionResult UpdateProfile(UserInfo user)
        {
            using (var dc = new QLKSEntities())
            {
                var u = dc.Users.Where(m => m.f_ID == user.UserID).FirstOrDefault();
                if (u != null)
                {
                    u.f_UserName = user.UserName;
                    u.f_Name = user.Name;

                    var a = dc.Users.Where(m => m.f_UserName == u.f_UserName).FirstOrDefault();
                    if (a != null)
                    {
                        ViewBag.ErrorMsg = "Tên đăng nhập đã tồn tại!";
                    }
                    else
                    {
                        dc.Entry(u).State = EntityState.Modified;
                        dc.SaveChanges();
                        Session["Logged"] = null;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return View("Profile");
        }
    }
}