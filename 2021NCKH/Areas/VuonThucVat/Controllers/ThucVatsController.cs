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
            ViewData["CTHH"] = db.ChiTietCTHHs.ToList();
            return View(thucVat);
        }
        public ActionResult Search(string keyword)
        {
            var model = db.ThucVats.ToList();
            //model = model.Where(p => p.TenVietNam.ToLower().Contains(keyword.ToLower())).ToList();
            model = (from s in model
                     where s.TenVietNam.ToLower().Contains(keyword.ToLower())
                     || s.TenKhac.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.TenLoaiThucVatDau.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.TenLoaiThucVatDuoi.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.ChiThucVat.TenChiThucVat.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.ChiThucVat.HoThucVat.TenHoThucVat.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.TenBoThucVat.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.TenPhanLopThucVat.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.LopThucVat.TenLopThucVat.ToLower().Contains(keyword.ToLower())
                     || s.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.LopThucVat.NganhThucVat.TenNganhThucVat.ToLower().Contains(keyword.ToLower())
                     select s).ToList();
            ViewBag.Keyword = keyword;
            return View("Index", model);
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
