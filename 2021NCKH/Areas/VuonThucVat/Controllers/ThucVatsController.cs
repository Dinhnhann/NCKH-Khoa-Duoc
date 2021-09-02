using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2021NCKH.Models;

namespace _2021NCKH.Areas.VuonThucVat.Controllers
{
    public class ThucVatsController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/ThucVats
        public ActionResult Index()
        {
            var thucVats = db.ThucVats.Include(t => t.LoaiThucVat);
            ViewData["Nganh"] = db.NganhThucVats.ToList();
            ViewData["Lop"] = db.LopThucVats.Include(t => t.NganhThucVat).ToList();
            ViewData["PhanLop"] = db.PhanLopThucVats.Include(t => t.LopThucVat).ToList();
            ViewData["Bo"] = db.BoThucVats.Include(t => t.PhanLopThucVat).ToList();
            ViewData["Ho"] = db.HoThucVats.Include(t => t.BoThucVat).ToList();
            ViewData["Chi"] = db.ChiThucVats.Include(t => t.HoThucVat).ToList();
            ViewData["Loai"] = db.LoaiThucVats.Include(t => t.ChiThucVat).ToList();
            return View(thucVats.ToList());
        }
        // GET: VuonThucVat/ThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucVat thucVat = db.ThucVats.Find(id);
            if (thucVat == null)
            {
                return HttpNotFound();
            }
            return View(thucVat);
        }
        public ActionResult Picture(int id)
        {
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + id, "images");
        }
        private const string PICTURE_PATH = "~/images/ThucVat/";
        // GET: VuonThucVat/ThucVats1/Create
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
