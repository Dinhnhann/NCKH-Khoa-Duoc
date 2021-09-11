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
    public class NganhThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/NganhThucVats
        public ActionResult Index()
        {
            return View(db.NganhThucVats.ToList());
        }

        // GET: Admin/NganhThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhThucVat nganhThucVat = db.NganhThucVats.Find(id);
            if (nganhThucVat == null)
            {
                return HttpNotFound();
            }
            return View(nganhThucVat);
        }

        // GET: Admin/NganhThucVats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/NganhThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNganhThucVat,TenNganhThucVat")] NganhThucVat nganhThucVat)
        {
            if (ModelState.IsValid)
            {
                db.NganhThucVats.Add(nganhThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nganhThucVat);
        }

        // GET: Admin/NganhThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhThucVat nganhThucVat = db.NganhThucVats.Find(id);
            if (nganhThucVat == null)
            {
                return HttpNotFound();
            }
            return View(nganhThucVat);
        }

        // POST: Admin/NganhThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNganhThucVat,TenNganhThucVat")] NganhThucVat nganhThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nganhThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nganhThucVat);
        }

        // GET: Admin/NganhThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NganhThucVat nganhThucVat = db.NganhThucVats.Find(id);
            if (nganhThucVat == null)
            {
                return HttpNotFound();
            }
            return View(nganhThucVat);
        }

        // POST: Admin/NganhThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NganhThucVat nganhThucVat = db.NganhThucVats.Find(id);
            db.NganhThucVats.Remove(nganhThucVat);
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
