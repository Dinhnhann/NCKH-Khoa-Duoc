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
    public class HoThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/HoThucVats
        public ActionResult Index()
        {
            var hoThucVats = db.HoThucVats.Include(h => h.BoThucVat);
            return View(hoThucVats.ToList());
        }

        // GET: Admin/HoThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoThucVat hoThucVat = db.HoThucVats.Find(id);
            if (hoThucVat == null)
            {
                return HttpNotFound();
            }
            return View(hoThucVat);
        }

        // GET: Admin/HoThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaBoThucVat = new SelectList(db.BoThucVats, "MaBoThucVat", "TenBoThucVat");
            return View();
        }

        // POST: Admin/HoThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHoThucVat,TenHoThucVat,MaBoThucVat")] HoThucVat hoThucVat)
        {
            if (ModelState.IsValid)
            {
                db.HoThucVats.Add(hoThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaBoThucVat = new SelectList(db.BoThucVats, "MaBoThucVat", "TenBoThucVat", hoThucVat.MaBoThucVat);
            return View(hoThucVat);
        }

        // GET: Admin/HoThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoThucVat hoThucVat = db.HoThucVats.Find(id);
            if (hoThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaBoThucVat = new SelectList(db.BoThucVats, "MaBoThucVat", "TenBoThucVat", hoThucVat.MaBoThucVat);
            return View(hoThucVat);
        }

        // POST: Admin/HoThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHoThucVat,TenHoThucVat,MaBoThucVat")] HoThucVat hoThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaBoThucVat = new SelectList(db.BoThucVats, "MaBoThucVat", "TenBoThucVat", hoThucVat.MaBoThucVat);
            return View(hoThucVat);
        }

        // GET: Admin/HoThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoThucVat hoThucVat = db.HoThucVats.Find(id);
            if (hoThucVat == null)
            {
                return HttpNotFound();
            }
            return View(hoThucVat);
        }

        // POST: Admin/HoThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HoThucVat hoThucVat = db.HoThucVats.Find(id);
            db.HoThucVats.Remove(hoThucVat);
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
