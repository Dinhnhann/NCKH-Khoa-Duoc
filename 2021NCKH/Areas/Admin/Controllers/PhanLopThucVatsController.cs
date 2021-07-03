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
    public class PhanLopThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/PhanLopThucVats
        public ActionResult Index()
        {
            var phanLopThucVats = db.PhanLopThucVats.Include(p => p.LopThucVat);
            return View(phanLopThucVats.ToList());
        }

        // GET: Admin/PhanLopThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLopThucVat phanLopThucVat = db.PhanLopThucVats.Find(id);
            if (phanLopThucVat == null)
            {
                return HttpNotFound();
            }
            return View(phanLopThucVat);
        }

        // GET: Admin/PhanLopThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaLopThucVat = new SelectList(db.LopThucVats, "MaLopThucVat", "TenLopThucVat");
            return View();
        }

        // POST: Admin/PhanLopThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPhanLopThucVat,TenPhanLopThucVat,MaLopThucVat")] PhanLopThucVat phanLopThucVat)
        {
            if (ModelState.IsValid)
            {
                db.PhanLopThucVats.Add(phanLopThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLopThucVat = new SelectList(db.LopThucVats, "MaLopThucVat", "TenLopThucVat", phanLopThucVat.MaLopThucVat);
            return View(phanLopThucVat);
        }

        // GET: Admin/PhanLopThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLopThucVat phanLopThucVat = db.PhanLopThucVats.Find(id);
            if (phanLopThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLopThucVat = new SelectList(db.LopThucVats, "MaLopThucVat", "TenLopThucVat", phanLopThucVat.MaLopThucVat);
            return View(phanLopThucVat);
        }

        // POST: Admin/PhanLopThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPhanLopThucVat,TenPhanLopThucVat,MaLopThucVat")] PhanLopThucVat phanLopThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanLopThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLopThucVat = new SelectList(db.LopThucVats, "MaLopThucVat", "TenLopThucVat", phanLopThucVat.MaLopThucVat);
            return View(phanLopThucVat);
        }

        // GET: Admin/PhanLopThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLopThucVat phanLopThucVat = db.PhanLopThucVats.Find(id);
            if (phanLopThucVat == null)
            {
                return HttpNotFound();
            }
            return View(phanLopThucVat);
        }

        // POST: Admin/PhanLopThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanLopThucVat phanLopThucVat = db.PhanLopThucVats.Find(id);
            db.PhanLopThucVats.Remove(phanLopThucVat);
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
