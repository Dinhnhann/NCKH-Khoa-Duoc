using _2021NCKH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Areas.Admin.Controllers
{
    public class CoCauToChucController : BaseController
    {
        private NCKHVLUEntities model = new NCKHVLUEntities();

        // GET: Admin/CoCauToChuc
        public ActionResult Index()
        {
            return View();
        }
    }
}