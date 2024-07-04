using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using System.Data.Entity;
using System.IO;

namespace Bizom.Controllers
{
   
    public class UpdateController : Controller
    {
    
        // GET: Update
        DbBIZ obj = new DbBIZ();
        public ActionResult Update(int id)
        {
            return View(obj.Retailers.Find(id));
        }
        [HttpPost]
        public ActionResult Update(Retailer R, HttpPostedFileBase pic)
        {
            string path = Path.GetFileName(pic.FileName);
            string name = Path.Combine(Server.MapPath("~/Image"), path);
            pic.SaveAs(name);
            R.Outlet_Image = path;
            obj.Entry(R).State = EntityState.Modified;
            obj.SaveChanges();
            return RedirectToAction("Read", "read");
        }
    }
}