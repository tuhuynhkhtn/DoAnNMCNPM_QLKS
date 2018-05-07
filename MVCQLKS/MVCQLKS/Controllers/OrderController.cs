using MVCQLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCQLKS.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult RegisOrder(int? id)
        {
            using (var dc = new QLKSEntities())
            {
                var room = dc.Rooms.Where(p => p.RoomID == id).FirstOrDefault();
                ViewBag.TenPhong= room.RoomName;
            }            
            return View();
        }
        //public ActionResult RegisOrder(int? id)
        //{
        //    if (!id.HasValue)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    using (var dc = new QLKSEntities())
        //    {
        //        var room = dc.Rooms.Where(p => p.RoomID == id).FirstOrDefault();
        //        return View(room);
        //    }
        //}

    }
}