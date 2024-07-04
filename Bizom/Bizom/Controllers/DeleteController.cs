using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;

namespace Bizom.Controllers
{
   
    public class DeleteController : Controller
    {
        
        // GET: Delete
        DbBIZ obj = new DbBIZ();
        public ActionResult Delete(int id)
        {
            obj.Retailers.Remove(obj.Retailers.Find(id));
            obj.SaveChanges();
            return RedirectToAction("read", "read");
        }
    }
}