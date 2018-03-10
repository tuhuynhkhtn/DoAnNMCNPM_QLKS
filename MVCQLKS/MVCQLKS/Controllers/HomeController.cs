using MVCQLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCQLKS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult HienThi3PhongConTrong()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms
                    .Where(p => p.Status == 0)
                    .OrderBy(p => p.RoomID)
                    .OrderByDescending(p => p.Price)
                    .Take(3)
                    .ToList();
                return PartialView("_Partial3PhongConTrong", l);
            }
        }

        // GET: Home
        public ActionResult HienThi3PhongDaChoThue()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms
                    .Where(p => p.Status == 1)
                    .OrderBy(p => p.RoomID)
                    .OrderByDescending(p => p.Price)
                    .Take(3)
                    .ToList();
                return PartialView("_Partial3PhongDaChoThue", l);
            }
        }
    }
}