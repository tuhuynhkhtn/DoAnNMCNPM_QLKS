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
        static int nPerPage = 6;
        // GET: Room
        public ActionResult GetListByCategory(int? id, int page = 1)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }
            using (var dc = new QLKSEntities())
            {
                int totalP = dc.Rooms.Where(p => p.CatID == id).Count();
                int nPage = totalP / nPerPage + (totalP % nPerPage > 0 ? 1 : 0);
                if(page < 1)
                {
                    page = 1;
                }
                if(page > nPage)
                {
                    page = nPage;
                }
                ViewBag.totalPage = nPage;
                ViewBag.curPage = page;

                var l = dc.Rooms
                    .Where(p => p.CatID == id)
                    .OrderBy(p => p.RoomID)
                    .Skip((page - 1) * nPerPage)
                    .Take(nPerPage)
                    .ToList();
                return View("ListByCategory", l);
            }
        }
    }
}