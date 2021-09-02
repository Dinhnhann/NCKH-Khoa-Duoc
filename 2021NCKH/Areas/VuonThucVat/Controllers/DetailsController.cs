using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using _2021NCKH.Models;
using System.Net;

namespace _2021NCKH.Areas.VuonThucVat.Controllers
{
    public class DetailsController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();
        public ActionResult Nganh()
        {
            return View(db.ThucVats.Include(t => t.LoaiThucVat).ToList());
        }
        public ActionResult Lop(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            NganhThucVat nganh = db.NganhThucVats.Find(id);
            if (nganh == null)
            {
                return HttpNotFound();
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.LopThucVat.NganhThucVat.MaNganhThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
        public ActionResult PhanLop(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.LopThucVat.MaLopThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
        public ActionResult Bo(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.MaPhanLopThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
        public ActionResult Ho(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.PhanLopThucVat.MaPhanLopThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
        public ActionResult Chi(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.ChiThucVat.HoThucVat.BoThucVat.MaBoThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
        public ActionResult Loai(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.ChiThucVat.MaChiThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
        public ActionResult Cay(int? id)
        {
            if (id == null)
            {
                return View(db.ThucVats.ToList());
            }
            var list = db.ThucVats.Where(p => p.LoaiThucVat.MaLoaiThucVat.ToString().Contains(id.ToString())).ToList();
            return View(list);
        }
    }
}