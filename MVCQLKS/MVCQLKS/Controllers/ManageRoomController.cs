using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCQLKS.Models;
using System.Data.Entity;
using MVCQLKS.Ultilities;
using System.Threading;

namespace MVCQLKS.Controllers
{
    [AuthActionFilter(RequiredPermission = 1)]
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
                    //var gia = Ulti.GetCatPrice(room.CatIDInfo);
                    var r = new Room
                    {
                        RoomName = room.RoomNameInfo,
                        //CatID = room.CatIDInfo,
                        //Price = gia,
                        RoomType = room.RoomTypeInfo,
                        Price = room.PriceInfo,
                        Status = room.StatusInfo,
                        MaximumCus = room.MaximumCusInfo
                    };

                    dc.Rooms.Add(r);
                    dc.SaveChanges();
                    return RedirectToAction("QuanLyRoom");
                }
            }
            return View("AddRoom");
        }

        // GET: ManageRoom/AddCat
        public ActionResult AddCat()
        {
            //var c = new CatInfo
            //{
            //    CatNameInfo = "cat",
            //    CatTypeInfo = "1",
            //    PriceInfo = 200000,
            //    NoteInfo = "cat"
            //};
            //return View(c);
            return View();
        }

        // POST: ManageRoom/AddCat
        [HttpPost]
        public ActionResult AddCat(CatInfo cat)
        {
            using (var dc = new QLKSEntities())
            {
                var catTonTai = dc.Categories.Where(m => m.CatName == cat.CatNameInfo).FirstOrDefault();
                if (catTonTai != null)
                {
                    ViewBag.ErrorMsg = "Tên phòng đã tồn tại";
                }
                else
                {
                    var c = new Category
                    {
                        CatName = cat.CatNameInfo,
                        CatType = cat.CatTypeInfo,
                        Price = cat.PriceInfo,
                        Note = cat.NoteInfo
                    };

                    dc.Categories.Add(c);
                    dc.SaveChanges();
                    return RedirectToAction("QuanLyCat");
                }
            }
            return View("AddCat");
        }

        // GET: ManageRoom/UpdateRoom
        public ActionResult UpdateRoom(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var rU = dc.Rooms.Where(c => c.RoomID == id).FirstOrDefault();
                var r = new RoomInfo
                {
                    RoomIDInfo = rU.RoomID,
                    RoomNameInfo = rU.RoomName,
                    //CatIDInfo = rU.CatID,
                    RoomTypeInfo = rU.RoomType,
                    PriceInfo = rU.Price,
                    StatusInfo = rU.Status,
                    MaximumCusInfo = rU.MaximumCus
                };
                return View(r);
            }
        }

        // POST: ManageProduct/UpdateInfoRoom
        [HttpPost]
        public ActionResult UpdateInfoRoom(RoomInfo room)
        {
            using (var dc = new QLKSEntities())
            {
                // Kiểm tra ID loại phòng nhập vào có tồn tại không
                var rU = dc.Rooms.Where(c => c.RoomID == room.RoomIDInfo).FirstOrDefault();
                //room.PriceInfo = Ulti.GetCatPrice(room.CatIDInfo);
                if (rU != null)
                {
                    rU.RoomName = room.RoomNameInfo;
                    //rU.CatID = room.CatIDInfo;   
                    rU.RoomType = room.RoomTypeInfo;                 
                    rU.Price = room.PriceInfo;
                    rU.Status = room.StatusInfo;
                    rU.MaximumCus = room.MaximumCusInfo;

                    //Kiểm tra tên loại phòng nhập vào có bị trùng không
                    var a = dc.Rooms.Where(c => c.RoomName == rU.RoomName && c.RoomID != rU.RoomID).FirstOrDefault();
                    if (a != null)
                    {
                        ViewBag.ErrorMsg = "Tên phòng đã tồn tại";
                    }
                    else
                    {
                        dc.Entry(rU).State = EntityState.Modified;
                        dc.SaveChanges();
                        return RedirectToAction("QuanLyRoom");
                    }
                }
            }
            return View("UpdateRoom");
        }

        // GET: ManageRoom/UpdateCat
        public ActionResult UpdateCat(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var cU = dc.Categories.Where(c => c.CatID == id).FirstOrDefault();
                var r = new CatInfo
                {
                    CatIDInfo = cU.CatID,
                    CatNameInfo = cU.CatName,
                    CatTypeInfo = cU.CatType,
                    PriceInfo = cU.Price,
                    NoteInfo = cU.Note
                };
                return View(r);
            }
        }

        [HttpPost]
        public ActionResult UpdateInfoCat(CatInfo cat)
        {
            using (var dc = new QLKSEntities())
            {
                // Kiểm tra ID loại phòng nhập vào có tồn tại không
                var catU = dc.Categories.Where(c => c.CatID == cat.CatIDInfo).FirstOrDefault();
                if (catU != null)
                {
                    catU.CatName = cat.CatNameInfo;
                    catU.CatType = cat.CatTypeInfo;
                    catU.Price = cat.PriceInfo;
                    catU.Note = cat.NoteInfo;

                    //Kiểm tra tên loại phòng nhập vào có bị trùng không
                    var a = dc.Categories.Where(c => c.CatName == catU.CatName && c.CatID != catU.CatID).FirstOrDefault();
                    if (a != null)
                    {
                        ViewBag.ErrorMsg = "Tên loại phòng đã tồn tại";
                    }
                    else
                    {
                        dc.Entry(catU).State = EntityState.Modified;
                        dc.SaveChanges();
                        return RedirectToAction("QuanLyCat");
                    }
                }
            }
            return View("UpdateCat");
        }



    }
}