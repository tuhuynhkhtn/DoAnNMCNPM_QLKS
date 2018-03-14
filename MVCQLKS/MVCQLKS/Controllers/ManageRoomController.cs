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

        // GET: ManageRoom/DeleteRoom
        public ActionResult DeleteRoom(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var rD = dc.Rooms.Where(c => c.RoomID == id).FirstOrDefault();
                if (rD != null)
                {
                    dc.Rooms.Remove(rD);
                    dc.SaveChanges();
                }
                return RedirectToAction("QuanLyRoom");
            }
        }

        // GET: ManageRoom/DeleteCat
        public ActionResult DeleteCat(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var cD = dc.Categories.Where(c => c.CatID == id).FirstOrDefault();
                if (cD != null)
                {
                    dc.Categories.Remove(cD);
                    dc.SaveChanges();
                }
                return RedirectToAction("QuanLyCat");
            }
        }

        // GET: ManageRoom/AddRoom
        public ActionResult AddRoom()
        {
            //var r = new RoomInfo
            //{
            //    RoomNameInfo = "room",
            //    CatIDInfo = 3,
            //    PriceInfo = 200000,
            //    StatusInfo = 0 //còn trống

            //};
            //return View(r);
            return View();
        }

        // POST: ManageRoom/AddRoom
        [HttpPost]
        public ActionResult AddRoom(RoomInfo room)
        {
            using (var dc = new QLKSEntities())
            {
                var roomTonTai = dc.Rooms.Where(m => m.RoomName == room.RoomNameInfo).FirstOrDefault();
                if (roomTonTai != null)
                {
                    ViewBag.ErrorMsg = "Tên phòng đã tồn tại";
                }
                else
                {
                    var r = new Room
                    {
                        RoomName = room.RoomNameInfo,
                        CatID = room.CatIDInfo,
                        Price = room.PriceInfo,
                        Status = room.StatusInfo
                    };

                    dc.Rooms.Add(r);
                    dc.SaveChanges();
                    return RedirectToAction("QuanLyRoom");
                }
            }
            //return RedirectToAction("QuanLyCat");
            return View("AddRoom");
        }

        // GET: ManageRoom/AddCat
        public ActionResult AddCat()
        {
            return View();
        }
    }
}