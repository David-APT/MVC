using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using System.IO;
using System.Net.Mail;
using System.Net;

namespace Bizom.Controllers
{
    public class CreateController : Controller
    {
        
        DbBIZ obj = new DbBIZ();
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Retailer R,HttpPostedFileBase pic)
        {
            if (ModelState.IsValid)
            {
                string path = Path.GetFileName(pic.FileName);
                string name = Path.Combine(Server.MapPath("~/Image"), path);
                pic.SaveAs(name);
                R.Outlet_Image = path;
                obj.Retailers.Add(R);
                obj.SaveChanges();

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("ramdineshproject@gmail.com");
                message.To.Add(new MailAddress(R.EMAIL));
                message.Subject = "Account Creared!";
                message.IsBodyHtml = true;
                message.Body = "Account Created Successfully";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ramdineshproject@gmail.com", "tigw msfs ptxi qbbt");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);


                TempData["MSG"] = "<script>alert('CREATED OUTLET')</script>";
                return RedirectToAction("Shop", "Shop");
                
            }
            else
            {
                return View();
            }

        }
      
    }
}