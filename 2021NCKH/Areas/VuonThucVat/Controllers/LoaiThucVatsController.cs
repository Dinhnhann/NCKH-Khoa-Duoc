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
    public class LoaiThucVatsController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/LoaiThucVats
        public ActionResult Index()
        {
            var loaiThucVats = db.LoaiThucVats.Include(l => l.ChiThucVat);
            return View(loaiThucVats.ToList());
        }

        // GET: VuonThucVat/LoaiThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThucVat loaiThucVat = db.LoaiThucVats.Find(id);
            if (loaiThucVat == null)
            {
                return HttpNotFound();
            }
            return View(loaiThucVat);
        }

        // GET: VuonThucVat/LoaiThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaChiThucVat = new SelectList(db.ChiThucVats, "MaChiThucVat", "TenChiThucVat");
            return View();
        }

        // POST: VuonThucVat/LoaiThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoaiThucVat,TenLoaiThucVat,MaChiThucVat")] LoaiThucVat loaiThucVat)
        {
            if (ModelState.IsValid)
            {
                db.LoaiThucVats.Add(loaiThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaChiThucVat = new SelectList(db.ChiThucVats, "MaChiThucVat", "TenChiThucVat", loaiThucVat.MaChiThucVat);
            return View(loaiThucVat);
        }

        // GET: VuonThucVat/LoaiThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThucVat loaiThucVat = db.LoaiThucVats.Find(id);
            if (loaiThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaChiThucVat = new SelectList(db.ChiThucVats, "MaChiThucVat", "TenChiThucVat", loaiThucVat.MaChiThucVat);
            return View(loaiThucVat);
        }

        // POST: VuonThucVat/LoaiThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoaiThucVat,TenLoaiThucVat,MaChiThucVat")] LoaiThucVat loaiThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaChiThucVat = new SelectList(db.ChiThucVats, "MaChiThucVat", "TenChiThucVat", loaiThucVat.MaChiThucVat);
            return View(loaiThucVat);
        }

        // GET: VuonThucVat/LoaiThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiThucVat loaiThucVat = db.LoaiThucVats.Find(id);
            if (loaiThucVat == null)
            {
                return HttpNotFound();
            }
            return View(loaiThucVat);
        }

        // POST: VuonThucVat/LoaiThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiThucVat loaiThucVat = db.LoaiThucVats.Find(id);
            db.LoaiThucVats.Remove(loaiThucVat);
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
