using _2021NCKH.Models;
using _2021NCKH.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        NCKHVLUEntities model = new NCKHVLUEntities();
        // GET: Admin/Admin
        public ActionResult Login()
        {
            ViewBag.Message = "Login.";
            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string password)
        {

            var admin = model.admins.FirstOrDefault(x => x.email == email);

            if (admin != null)
            {
                if (admin.password.Equals(password))
                {
                    Session["FullName"] = admin.fullname;
                    Session["UserID"] = admin.admin_id;
                    return RedirectToAction("Dashboard", "Home");
                }
            }
            else
            {
                ViewBag.Message = "tài khoản không tồn tại";
            }
            return View();
        }
        public ActionResult Logout(int id)
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}