using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCQLKS.Models;
using System.Data.Entity;

namespace MVCQLKS.Views
{
    public class EmployController : Controller
    {
        //// GET: Employ
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: ManageRoom/QuanLyCusBookRoom
        public ActionResult QuanLyCusBookRoom()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Customers.Where(c => c.BookRoom == 1).ToList();
                return View(l);
            }
        }

        // GET: ManageRoom/QuanLyCusChoNV
        public ActionResult QuanLyCusChoNV()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Customers.ToList();
                return View(l);
            }
        }

        public ActionResult DeleteCusBookRoom(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var cD = dc.Customers.Where(c => c.CusID == id).FirstOrDefault();
                if (cD != null)
                {
                    dc.Customers.Remove(cD);
                    dc.SaveChanges();
                }
                return RedirectToAction("QuanLyCusBookRoom");
            }
        }

        public ActionResult DeleteCus(int id)
        {
            using (var dc = new QLKSEntities())
            {
                var cD = dc.Customers.Where(c => c.CusID == id).FirstOrDefault();
                if (cD != null)
                {
                    dc.Customers.Remove(cD);
                    dc.SaveChanges();
                }
                return RedirectToAction("QuanLyCusChoNV");
            }
        }

        public ActionResult AddCusBookRoom()
        {
            //var r = new CusInfo
            //{
            //    CusNameInfo = "cus",
            //    CusTypeIDInfo = 1,
            //    CusIDCardInfo = "019890089",
            //    CusAddressInfo = "abc",
            //    //RoomIDInfo = ' ',
            //    BookRoomInfo = 1
            //};
            //return View(r);
            return View();
        }

        [HttpPost]
        public ActionResult AddCusBookRoom(CusInfo cus)
        {
            using (var dc = new QLKSEntities())
            {
                var cusTonTai = dc.Customers.Where(m => m.CusIDCard == cus.CusIDCardInfo).FirstOrDefault();
                if (cusTonTai != null)
                {
                    ViewBag.ErrorMsg = "CMND đã tồn tại";
                }
                else
                {
                    //var gia = Ulti.GetCatPrice(room.CatIDInfo);
                    var r = new Customer
                    {
                        CusName = cus.CusNameInfo,
                        CusTypeID = cus.CusTypeIDInfo,
                        CusIDCard = cus.CusIDCardInfo,
                        CusAddress = cus.CusAddressInfo,
                        RoomID = 0,
                        BookRoom = 1
                    };

                    dc.Customers.Add(r);
                    dc.SaveChanges();
                    return RedirectToAction("QuanLyCusBookRoom");
                }
            }
            return View("AddCusChoNV");
        }

        public ActionResult AddCus()
        {
            var r = new CusInfo
            {
                CusNameInfo = "cus",
                CusTypeIDInfo = 1,
                CusIDCardInfo = "019890089",
                CusAddressInfo = "abc",
                RoomIDInfo = 1,
                BookRoomInfo = 1
            };
            return View(r);
            //return View();
        }

        [HttpPost]
        public ActionResult AddCus(CusInfo cus)
        {
            using (var dc = new QLKSEntities())
            {
                var cusTonTai = dc.Customers.Where(m => m.CusIDCard == cus.CusIDCardInfo).FirstOrDefault();
                if (cusTonTai != null)
                {
                    ViewBag.ErrorMsg = "CMND đã tồn tại";
                }
                else
                {
                    //var gia = Ulti.GetCatPrice(room.CatIDInfo);
                    var r = new Customer
                    {
                        CusName = cus.CusNameInfo,
                        CusTypeID = cus.CusTypeIDInfo,
                        CusIDCard = cus.CusIDCardInfo,
                        CusAddress = cus.CusAddressInfo,
                        RoomID = cus.RoomIDInfo,
                        BookRoom = cus.BookRoomInfo
                    };

                    dc.Customers.Add(r);
                    dc.SaveChanges();
                    return RedirectToAction("QuanLyCusChoNV");
                }
            }
            return View("AddCus");
        }

        //GET: ManageCustomer
        public ActionResult CustomerList()
        {
            List<Customer> c = null;
            using (var cus = new QLKSEntities())
            {
                c = cus.Customers.ToList();
            }
            return View(c);
        }

        public ActionResult DetailCus(int cusId)
        {
            Customer c = null;
            using (var cus = new QLKSEntities())
            {
                c = cus.Customers.Where(x => x.CusID == cusId).FirstOrDefault();
            }
                return View(c);
        }

        //Them - Xoa - Sua DS Khach Hang
        public ActionResult AddCusChoNV()
        {
            return View();
        }

        [HttpPost]

        public ActionResult AddCusChoNV(string CusName)
        {
            List<Customer> l = null;
            using (var c = new QLKSEntities())
            {
                Customer cus = new Customer { CusName = CusName };
                c.Customers.Add(cus);
                c.SaveChanges();
                l = c.Customers.ToList();
            }
            return View("CustomerList", l);
        }

        public ActionResult DeleteCusChoNV(int cusID)
        {
            List<Customer> l = null;
            using (var c = new QLKSEntities())
            {
                var cus = c.Customers.Where(cs => cs.CusID == cusID).FirstOrDefault();
                if (cus != null)
                {
                    c.Customers.Remove(cus);
                    c.SaveChanges();
                }
                l = c.Customers.ToList();
            }
            return View("CustomerList", l);
        }

        public ActionResult EditCusChoNV(int cusID)
        {
            Customer cus = null;
            using (var c = new QLKSEntities())
            {
                cus = c.Customers.Where(cs => cs.CusID == cusID).FirstOrDefault();
            }
            return View(cus);
        }

        [HttpPost]

        public ActionResult EditCusChoNV(Customer cusNew)
        {
            List<Customer> l = null;
            using (var c = new QLKSEntities())
            {
                var cusOld = c.Customers.Where(cs => cs.CusID == cusNew.CusID).FirstOrDefault();
                if (cusOld != null)
                {
                    cusOld.CusName = cusNew.CusName;
                    c.Entry(cusOld).State = EntityState.Modified;
                    c.SaveChanges();
                }
                l = c.Customers.ToList();
            }
            return View("CustomerList", l);
        }

        // GET: ManageRoom/QuanLyRoomChoNV
        public ActionResult QuanLyRoomChoNV()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms.ToList();
                return View(l);
            }
        }

        // GET: ManageCategory/QuanLyCatChoNV
        public ActionResult QuanLyCatChoNV()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Categories.ToList();
                return View(l);
            }
        }

        // GET: ManageCategory/AddCatChoNV
        public ActionResult AddCatChoNV()
        {
            return View();
        }

        // GET: ManageCategory/AddRoomChoNV
        public ActionResult AddRoomChoNV()
        {
            return View();
        }


    }
}