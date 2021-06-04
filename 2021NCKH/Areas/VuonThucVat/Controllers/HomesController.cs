using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2021NCKH.Areas.VuonThucVat.Data;

namespace _2021NCKH.Areas.VuonThucVat.Controllers
{
    public class HomesController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/HomesCayThucVats1
        public ActionResult Index()
        {
            var cayThucVats = db.CayThucVats.Include(c => c.Loai1);
            return View(cayThucVats.ToList());
        }
    }
}