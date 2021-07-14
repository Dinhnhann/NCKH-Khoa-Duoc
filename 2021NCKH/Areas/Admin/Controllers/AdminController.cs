using _2021NCKH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Areas.Admin.Controllers
{

    public class AdminController : Controller
    {
        private NCKHVLUEntities model = new NCKHVLUEntities();

        public ActionResult Index()
        {
            var adm = model.admins.OrderByDescending(x => x.admin_id).ToList();
            return View(adm);
        }

        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.Message = "Vui lòng đăng nhập để tiếp tục !!!";
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
                ViewBag.Message = "Thông tin không chính xác !!!";
            }
            return View();
        }
        public ActionResult Logout(int id)
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(admin admin)
        {
            var adm = new admin();
            adm.fullname = admin.fullname;
            adm.username = admin.username;
            adm.email = admin.email;
            adm.password = admin.password;
            model.admins.Add(adm);
            model.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var adm = model.admins.FirstOrDefault(x => x.admin_id == id);
            return View(adm);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var adm = model.admins.FirstOrDefault(x => x.admin_id == id);
            model.admins.Remove(adm);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}