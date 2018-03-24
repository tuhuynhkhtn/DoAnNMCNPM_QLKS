using MVCQLKS.Models;
using MVCQLKS.Ultilities;
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

        public ActionResult IndexRoomAdmin(int permiss)
        {
            AddHelpers.RoomAdmin = true;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult HienThi3PhongConTrong()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms
                    .Where(p => p.Status == 0)
                    .OrderByDescending(p => p.RoomID)
                    .Take(3)
                    .ToList();

                return PartialView("_Partial3PhongConTrong", l);
            }
        }

        public ActionResult HienThi3PhongDaChoThue()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms
                    .Where(p => p.Status == 1)
                    .OrderBy(p => p.RoomID)
                    .Take(3)
                    .ToList();

                return PartialView("_Partial3PhongDaChoThue", l);
            }
        }
    }
}