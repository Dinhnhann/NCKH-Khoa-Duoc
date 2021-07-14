using _2021NCKH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Controllers
{
    public class CacBoMonController : Controller
    {
        private NCKHVLUEntities model = new NCKHVLUEntities();
        // GET: CacBoMon
        public ActionResult Index()
        {
            return View();
        }
    }
}