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
    }
}