using MVCQLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCQLKS.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult GetListByCategory(int catId)
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Rooms.Where(p => p.CatID == catId).ToList();
                return View("ListByCategory", l);
            }
        }
    }
}