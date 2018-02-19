using MVCQLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCQLKS.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult GetList()
        {
            using (var dc = new QLKSEntities())
            {
                var l = dc.Categories.ToList();
                return PartialView("_PartialGetList", l);
            }
        }
    }
}