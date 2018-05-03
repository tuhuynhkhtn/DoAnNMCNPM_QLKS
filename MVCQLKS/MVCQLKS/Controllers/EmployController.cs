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