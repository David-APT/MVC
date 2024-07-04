using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Bizom.Models;
using System.IO;

namespace Bizom.Controllers
{
    public class PRODUCT_EDIT_DELETEController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult PRODUCT_EDIT_DELETE(int id)
        {
            return View(obj.products.Find(id));
        }
        [HttpPost]
        public ActionResult PRODUCT_EDIT_DELETE(product R, HttpPostedFileBase PIC)
        {
            string path = Path.GetFileName(PIC.FileName);
            string P = Server.MapPath("~/PRODUCT IMAGE/" + path);
            PIC.SaveAs(P);
            R.PRODUCT_IMAGE = path;
            obj.Entry(R).State = EntityState.Modified;
            obj.SaveChanges();

            return RedirectToAction("PRODUCTREAD","PRODUCTREAD");
        }
        public ActionResult PRODUCT_DELETE(int id)
        {
            obj.products.Remove(obj.products.Find(id));
            obj.SaveChanges();
            return RedirectToAction("PRODUCTREAD", "PRODUCTREAD");
        }
    }
}