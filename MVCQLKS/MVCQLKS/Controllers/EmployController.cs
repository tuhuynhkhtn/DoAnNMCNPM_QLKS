using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCQLKS.Models;

namespace MVCQLKS.Views
{
    public class EmployController : Controller
    {
        //// GET: Employ
        //public ActionResult Index()
        //{
        //    return View();
        //}

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