using BotDetect.Web.Mvc;
using MVCQLKS.Models;
using MVCQLKS.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
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
                    Session["Logged"] = ui;
                    Response.Cookies["UserId"].Value = user.f_ID.ToString();
                    Response.Cookies["UserId"].Expires = DateTime.Now.AddDays(7);

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

            return RedirectToAction("Index", "Home");
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
                ViewBag.ErrorMsg = "Captcha chưa đúng!";
            }
            else
            {
                var u = new User
                {
                    f_UserName = user.UserName,
                    f_Password = Ulti.Md5Hash(user.Password),
                    f_Name = user.Name
                };
                using (var dc = new QLKSEntities())
                {
                    dc.Users.Add(u);
                    dc.SaveChanges();
                }
                var ui = new UserInfo { UserName = u.f_UserName };
                Session["Logged"] = ui;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [AuthActionFilter]

        public ActionResult Profile()
        {
            /*if (Session["Logged"] == null)
            {
                return RedirectToAction("Login", "Account");
            }*/
            var ui = Session["Logged"] as UserInfo;
            return View(ui);
        }
    }
}