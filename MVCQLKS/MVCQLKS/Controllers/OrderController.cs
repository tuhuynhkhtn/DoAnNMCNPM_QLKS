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
        public ActionResult RegisterOrder(int? id)
        {
            using (var dc = new QLKSEntities())
            {
                var room = dc.Rooms.Where(p => p.RoomID == id).FirstOrDefault();
                ViewBag.IdPhong = room.RoomID;
                //return View(room);
                return View();
            }            
        }

        public ActionResult KiemTraCMNDDatPhong(CusInfo cus)
        {
            //String Id = Request.Form["Id"];
            //String CMND = Request.Form["Cmnd"];
            //double Marks = Convert.ToDouble(Request.Form[“Marks”]);

            String Id = Request.Form["Id"];
            String CMND = cus.CusIDCardInfo;

            ViewBag.id = Id;
            ViewBag.cmnd = CMND;
            ViewBag.IdPhong = Id;

            using (var dc = new QLKSEntities())
            {
                var cusTonTai = dc.Customers.Where(m => m.CusIDCard == CMND).FirstOrDefault();
                if (cusTonTai == null)
                {
                    ViewBag.ErrorMsg = "CMND chưa tồn tại";
                }
                else
                {
                    return View("RegisterOrderNext");
                }
            }
            return View("RegisterOrder");
        }

        public ActionResult KiemTraNgayTraPhong(OrderDetailInfo order)
        {
            String Id = Request.Form["Id"];
            String CMND = Request.Form["Cmnd"];
            DateTime Date = order.OrderCheckOutInfo;

            ViewBag.id = Id;
            ViewBag.cmnd = CMND;
            ViewBag.date = Date;

            DateTime dtNow = DateTime.Now;
            DateTime dt = order.OrderCheckOutInfo;

            int result = DateTime.Compare(dt, dtNow);
            if (result < 0)
            {
                ViewBag.ErrorMsg = "Ngày trả phòng phải lớn hơn hoặc bằng ngày hiện tại";
            }


            return View("RegisterOrderLast");
        }

    }
}