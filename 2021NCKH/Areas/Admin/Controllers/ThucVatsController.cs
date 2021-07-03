using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2021NCKH.Models;

namespace _2021NCKH.Areas.Admin.Controllers
{
    public class ThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/ThucVats
        public ActionResult Index()
        {
            var thucVats = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(thucVats.ToList());
        }

        // GET: Admin/ThucVats/Details/5
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

        // GET: Admin/ThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat");
            return View();
        }

        // POST: Admin/ThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCay,HinhAnh,TenVietNam,TenKhoaHoc,HoThucVat,MoTa,BoPhanDung,ThanhPhanHoaHoc,TacDungDuocLy,LieuDung,TaiLieuThamKhao,MaLoaiThucVat")] ThucVat thucVat)
        {
            if (ModelState.IsValid)
            {
                db.ThucVats.Add(thucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat", thucVat.MaLoaiThucVat);
            return View(thucVat);
        }

        // GET: Admin/ThucVats/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat", thucVat.MaLoaiThucVat);
            return View(thucVat);
        }

        // POST: Admin/ThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCay,HinhAnh,TenVietNam,TenKhoaHoc,HoThucVat,MoTa,BoPhanDung,ThanhPhanHoaHoc,TacDungDuocLy,LieuDung,TaiLieuThamKhao,MaLoaiThucVat")] ThucVat thucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat", thucVat.MaLoaiThucVat);
            return View(thucVat);
        }

        // GET: Admin/ThucVats/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Admin/ThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ThucVat thucVat = db.ThucVats.Find(id);
            db.ThucVats.Remove(thucVat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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
