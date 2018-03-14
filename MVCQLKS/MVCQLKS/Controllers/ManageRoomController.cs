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

        // GET: ManageRoom/QuanLyRoom
        public ActionResult QuanLyRoom()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms.ToList();
                return View(l);
            }
        }

        // GET: ManageRoom/QuanLyCat
        public ActionResult QuanLyCat()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Categories.ToList();
                return View(l);
            }
        }
        // GET: ManageRoom/AddCat
        public ActionResult AddCat()
        {
            return View();
        }

        // GET: ManageRoom/AddRoom
        public ActionResult AddRoom()
        {
            return View();
        }

        // GET: ManageRoom/DeleteRoom
        public ActionResult DeleteRoom(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var rD = dc.Rooms.Where(c => c.RoomID == id).FirstOrDefault();
                if (rD != null)
                {
                    //cD.BiXoa = 1;
                    dc.Rooms.Remove(rD);
                    dc.SaveChanges();
                }
                return RedirectToAction("QuanLyRoom");
            }
        }

    }
}