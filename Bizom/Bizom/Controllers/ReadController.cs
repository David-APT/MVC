using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using PagedList;

namespace Bizom.Controllers
{
    [Authorize()]
    public class ReadController : Controller
    {

        DbBIZ obj = new DbBIZ();
        int PageSize = 10;
        int PageIndex = 1;
        public ActionResult Read(int ? page)
        {
            ViewBag.Co = obj.Retailers.Count();
            PageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            return View(obj.Retailers.OrderBy(m=>m.Retailer_Id).ToPagedList(PageIndex, PageSize));
        }
    }
}