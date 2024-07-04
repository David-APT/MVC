using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;

namespace Bizom.Controllers
{
    public class AccountCreationReadController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult AccountCreationRead()
        {
            return View(obj.AccountCreations.ToList());
        }
        public ActionResult Activate(int i)
        {
            var k = obj.AccountCreations.Find(i);
            k.status = "Approve";
            obj.SaveChanges();
            return RedirectToAction("AccountCreationRead");
        }
    }
}