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
    public class ThucVatController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();
        // GET: VuonThucVat/ThucVat
        public ActionResult Nganh()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
        public ActionResult Lop()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
        public ActionResult PhanLop()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
        public ActionResult Bo()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
        public ActionResult Ho()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
        public ActionResult Chi()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
        public ActionResult Loai()
        {
            var list = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(list.ToList());
        }
    }
}