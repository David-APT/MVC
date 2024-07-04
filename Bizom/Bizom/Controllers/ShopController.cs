using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;

namespace Bizom.Controllers
{
    public class ShopController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult Shop(string day)
        {
           
            if (day == "MONDAY")
            {
                ViewBag.co = obj.Retailers.Where(m => m.Select_Beat.Equals("BURMACOLONY")).Count();
                return View(obj.Retailers.Where(m => m.Select_Beat.Equals("BURMACOLONY")).ToList());
            }
            else if (day == "TUESDAY")
            {
                ViewBag.co = obj.Retailers.Where(m => m.Select_Beat.Equals("KALANIVASAL")).Count();
                return View(obj.Retailers.Where(m => m.Select_Beat.Equals("KALANIVASAL")).ToList());
            }
            else if (day == "WEDNESDAY")
            {
                ViewBag.co = obj.Retailers.Where(m => m.Select_Beat.Equals("SENJAI")).Count();
                return View(obj.Retailers.Where(m => m.Select_Beat.Equals("SENJAI")).ToList());
            }
            else if (day == "THURSDAY")
            {
                ViewBag.co = obj.Retailers.Where(m => m.Select_Beat.Equals("RAILWAYROAD")).Count();
                return View(obj.Retailers.Where(m => m.Select_Beat.Equals("RAILWAYROAD")).ToList());
            }
            else if (day == "FRIDAY")
            {
                ViewBag.co = obj.Retailers.Where(m => m.Select_Beat.Equals("PALLATHUR")).Count();
                return View(obj.Retailers.Where(m => m.Select_Beat.Equals("PALLATHUR")).ToList());
            }
            else if (day == "SATURDAY")
            {
                ViewBag.co = obj.Retailers.Where(m => m.Select_Beat.Equals("PUTHUVAYAL")).Count();
                return View(obj.Retailers.Where(m => m.Select_Beat.Equals("PUTHUVAYAL")).ToList());
            }
            else
            {
                return View(obj.Retailers.ToList());
            }

        }
    }
}