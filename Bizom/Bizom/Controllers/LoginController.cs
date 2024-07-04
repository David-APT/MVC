using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using System.Web.Security;
using System.Net.Mail;
using System.Net;

namespace Bizom.Controllers
{
    public class LoginController : Controller
    {

        DbBIZ log = new DbBIZ();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Login L)
        {
            if (ModelState.IsValid)
            {
                //    string dy = DateTime.Now.ToString("HH:mm");
                //&& dy==L.DPassword
                int c = log.AccountCreations.Where(m => m.CREATERE_USERNAME.Equals(L.UserName) &&
                                                   m.CREATERE_PASSWORD.Equals(L.PassWord) && m.Roles.Equals(L.Roles) && m.status=="Approve").Count();
                Random f = new Random();
                int ran=f.Next(1000, 9999);
                if (c != 0)
                {
                    
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("vijayproject2023@gmail.com");//admin mail Address
                    message.To.Add(new MailAddress("davidselvamani2303@gmail.com"));//user mail Address
                    message.Subject = "OTP Mail";
                    message.IsBodyHtml = true; //to make message body as html  
                    message.Body = "<h1>Your One Time Password is </h1>" + ran;
                    smtp.Port = 587;//mail code
                    smtp.Host = "smtp.gmail.com"; //for gmail host  
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("vijayproject2023@gmail.com", "qgvf jsxi dqco flwc");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;// while using network
                    smtp.Send(message);
                    FormsAuthentication.SetAuthCookie(L.UserName, false);
                    return RedirectToAction("Shop", "Shop");
                    //return RedirectToAction("read", "read");
                }
                else
                {
                    TempData["msg"] = "<script>alert('login fail')</script>";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        //public ActionResult LP(Retailer R, Login a)
        //{
        //    int c = log.AccountCreations.Where(m => m.CREATERE_USERNAME.Equals(a.UserName) && m.CREATERE_PASSWORD.Equals(a.PassWord) && a.Roles.Equals(a.Roles)).Count();
        //    //int c = obj.UserAccounts.Where(m => m.Customer_Name.Equals(a.UserName) && m.Password.Equals(a.Password) && a.Role == "Client" && m.Status == "Active").Count();
        //    if (ModelState.IsValid)
        //    {
        //        if (a.UserName == "DS2303" && a.PassWord == "230397" && a.Roles == "Admin")
        //        {
        //            FormsAuthentication.SetAuthCookie(a.UserName, false);
        //            return RedirectToAction("Shop", "Shop");
        //        }
        //        else if (c != 0)
        //        {

        //            try
        //            {

        //                TempData["mail"] = log.AccountCreations.Where(m => m.CREATERE_USERNAME.Equals(a.UserName) && m.CREATERE_PASSWORD.Equals(a.PassWord) && a.Roles == "Staff").Select(m => R.EMAIL).FirstOrDefault();
        //                TempData["ID"] = log.AccountCreations.Where(m => m.CREATERE_USERNAME.Equals(a.UserName) && m.CREATERE_PASSWORD.Equals(a.PassWord) && a.Roles == "Staff").Select(m => R.Retailer_Id).FirstOrDefault();
        //                Random rnd = new Random();
        //                int ran = rnd.Next(1000, 9999);
        //                int i = Convert.ToInt32(TempData["ID"]);
        //                var x = log.AccountCreations.Find(i);
        //                TempData.Keep();
        //                int j = x.dt.Minute + 1;
        //                if (DateTime.Now.Minute >= j || x.otp == null)
        //                {
        //                    x.otp = ran.ToString();
        //                    x.dt = DateTime.Now;
        //                }

        //                log.SaveChanges();
        //                string mail = TempData["mail"].ToString();
        //                MailMessage message = new MailMessage();
        //                SmtpClient smtp = new SmtpClient();
        //                message.From = new MailAddress("vijayproject2023@gmail.com");//admin mail Address
        //                message.To.Add(new MailAddress(mail));//user mail Address
        //                message.Subject = "OTP Mail";
        //                message.IsBodyHtml = true; //to make message body as html  
        //                message.Body = "<h1>Your One Time Password is </h1>" + ran;
        //                smtp.Port = 587;//mail code
        //                smtp.Host = "smtp.gmail.com"; //for gmail host  
        //                smtp.EnableSsl = true;
        //                smtp.UseDefaultCredentials = false;
        //                smtp.Credentials = new NetworkCredential("vijayproject2023@gmail.com", "qgvf jsxi dqco flwc");
        //                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;// while using network
        //                smtp.Send(message);
        //                FormsAuthentication.SetAuthCookie(a.UserName, false);
        //                return RedirectToAction("OTP", "Home");
        //            }
        //            catch (Exception e)
        //            {
        //                return RedirectToAction("Nointernet");
        //            }

        //        }
        //        else
        //        {
        //            int l = log.AccountCreations.Where(m => m.CREATERE_USERNAME == a.UserName).Select(m => m.CREATERE_Id).FirstOrDefault();
        //            var k = log.AccountCreations.Find(l);
        //            if (k.fake > 2)
        //            {

        //                return RedirectToAction("fakeDashboard");
        //            }
        //            else
        //            {
        //                k.fake += 1;
        //                log.SaveChanges();
        //                TempData["fake"] = "<script>alert(`Invalid User name and Password`)</script>";
        //                TempData["style"] = "visibility:visible!important;";
        //                return RedirectToAction("Home", "Home");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        TempData["style"] = "visibility:visible!important;";
        //        return View();

        //    }
        //}
        //public ActionResult Storage()
        //{
        //    return View();
        //}
        //public ActionResult OTP()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult OTP(string o1, string o2, string o3, string o4)
        //{
        //    string otpnumber = o1 + o2 + o3 + o4;
        //    int i = Convert.ToInt32(TempData["ID"].ToString());
        //    TempData.Keep();
        //    var k = log.AccountCreations.Find(i);

        //    if (k.otp.Equals(otpnumber))
        //    {
        //        return RedirectToAction("dyanmicpassword", "Home");

        //    }
        //    else
        //    {
        //        TempData["otp"] = "<script>alert(`Invalid OTP`)</script>";
        //        return RedirectToAction("Home", "Home");
        //    }
        //}
        //public ActionResult Nointernet()
        //{
        //    return View();
        //}
        //public ActionResult dyanmicpassword()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult dyanmicpassword(string DyanmicPassword)
        //{
        //    DateTime l = DateTime.Now;
        //    string psd = l.Hour.ToString() + l.Minute.ToString();
        //    TempData.Keep();
        //    if (psd == DyanmicPassword)
        //    {
        //        return RedirectToAction("Storage", "Home");
        //    }
        //    else
        //    {
        //        TempData["pass"] = "<script>alert(`Invalid Password`)</script>";
        //        return RedirectToAction("dyanmicpassword", "Home");
        //    }
        //}
        //public ActionResult fakeDashboard()
        //{
        //    return View();
        //}
    }

}

