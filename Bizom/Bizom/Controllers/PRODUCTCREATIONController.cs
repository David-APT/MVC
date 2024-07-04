using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using System.IO;

namespace Bizom.Controllers
{
    public class PRODUCTCREATIONController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult PRODUCTCREATION()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PRODUCTCREATION(product R,HttpPostedFileBase PIC)
        {
            string path = Path.GetFileName(PIC.FileName);
            string name = Server.MapPath("~/PRODUCT IMAGE/"+ path);
            PIC.SaveAs(name);
            R.PRODUCT_IMAGE = path;
            obj.products.Add(R);
            obj.SaveChanges();

            return RedirectToAction("PRODUCTCREATION", "PRODUCTCREATION");
        }
    }
}