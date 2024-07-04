using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;

namespace Bizom.Controllers
{
    public class AccountCreationController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult AccountCreationPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccountCreationPage(AccountCreation R)
        {
            obj.AccountCreations.Add(R);
            obj.SaveChanges();
            return RedirectToAction("AccountCreationPage", "AccountCreation");
        }
    }
}