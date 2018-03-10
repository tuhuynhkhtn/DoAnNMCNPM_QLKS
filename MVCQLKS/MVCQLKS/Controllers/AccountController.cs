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

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Register(UserRegisting user)
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
            return View();
        }
    }
}