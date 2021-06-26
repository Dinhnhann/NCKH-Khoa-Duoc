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
        CommonService commonService = new CommonService();

        // GET: Admin/Admin
        public ActionResult Login()
        {
            ViewBag.Message = "Login.";
            return View();
        }
    }
}