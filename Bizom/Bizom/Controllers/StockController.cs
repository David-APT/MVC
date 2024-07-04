using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
namespace Bizom.Controllers
{
    public class StockController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public static int c = 0;
        public ActionResult Stock()
       {
          if(c!=0)
          {
              ViewBag.Cat = obj.products.Where(m => m.PRODUCT_BRAND != null).Select(m => m.PRODUCT_BRAND).ToList().Distinct();
              c = 0;
              return View(obj.products.ToList());
          
          }
          else
          {
              return RedirectToAction("EyeLogin");
          }
        }
        [HttpPost]
        public ActionResult Stock(string accountid)
        {
            ViewBag.Cat = obj.products.Where(m => m.PRODUCT_BRAND != null).Select(m => m.PRODUCT_BRAND).ToList().Distinct();
            return View(obj.products.Where(m=>m.PRODUCT_BRAND.Contains(accountid)).ToList());
        }
        public ActionResult EyeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EyeLogin(Login s)
        {
            string dt = DateTime.Now.ToString("HH:mm");
            if(s.DPassword==dt)
            {
                c++;
                return RedirectToAction("Stock");
            }
            else
            {
                c = 0;
                return RedirectToAction("Login", "Login");
            }
        }
    }
}