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
    public class LopThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/LopThucVats
        public ActionResult Index()
        {
            var lopThucVats = db.LopThucVats.Include(l => l.NganhThucVat);
            return View(lopThucVats.ToList());
        }

        // GET: Admin/LopThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopThucVat lopThucVat = db.LopThucVats.Find(id);
            if (lopThucVat == null)
            {
                return HttpNotFound();
            }
            return View(lopThucVat);
        }

        // GET: Admin/LopThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaNganhThucVat = new SelectList(db.NganhThucVats, "MaNganhThucVat", "TenNganhThucVat");
            return View();
        }

        // POST: Admin/LopThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLopThucVat,TenLopThucVat,MaNganhThucVat")] LopThucVat lopThucVat)
        {
            if (ModelState.IsValid)
            {
                db.LopThucVats.Add(lopThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNganhThucVat = new SelectList(db.NganhThucVats, "MaNganhThucVat", "TenNganhThucVat", lopThucVat.MaNganhThucVat);
            return View(lopThucVat);
        }

        // GET: Admin/LopThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopThucVat lopThucVat = db.LopThucVats.Find(id);
            if (lopThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNganhThucVat = new SelectList(db.NganhThucVats, "MaNganhThucVat", "TenNganhThucVat", lopThucVat.MaNganhThucVat);
            return View(lopThucVat);
        }

        // POST: Admin/LopThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLopThucVat,TenLopThucVat,MaNganhThucVat")] LopThucVat lopThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNganhThucVat = new SelectList(db.NganhThucVats, "MaNganhThucVat", "TenNganhThucVat", lopThucVat.MaNganhThucVat);
            return View(lopThucVat);
        }

        // GET: Admin/LopThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopThucVat lopThucVat = db.LopThucVats.Find(id);
            if (lopThucVat == null)
            {
                return HttpNotFound();
            }
            return View(lopThucVat);
        }

        // POST: Admin/LopThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LopThucVat lopThucVat = db.LopThucVats.Find(id);
            db.LopThucVats.Remove(lopThucVat);
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
