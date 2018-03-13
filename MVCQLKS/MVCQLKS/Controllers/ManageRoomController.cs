using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCQLKS.Models;

namespace MVCQLKS.Controllers
{
    public class ManageRoomController : Controller
    {
        // GET: ManageRoom/IndexManageRoom
        public ActionResult IndexManageRoom()
        {
            return View();
        }

        //// GET: ManageRoom/QuanLyRoom
        //public ActionResult QuanLyRoom()
        //{
        //    using (var dc = new QLKSEntities())
        //    {
        //        var l = dc.Rooms.ToList();
        //        return View(l);
        //    }
        //}

        //// GET: ManageCategory/QuanLyCat
        //public ActionResult QuanLyCat()
        //{
        //    using (var dc = new QLKSEntities())
        //    {
        //        var l = dc.Categories.ToList();
        //        return View(l);
        //    }
        //}

    }
}