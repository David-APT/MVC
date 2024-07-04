using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;

namespace Bizom.Controllers
{
    public class PRODUCTREADController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult PRODUCTREAD()
        {
            return View(obj.products.ToList());
        }
    }
}