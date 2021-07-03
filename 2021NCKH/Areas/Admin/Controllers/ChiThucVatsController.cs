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
    public class ChiThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/ChiThucVats
        public ActionResult Index()
        {
            var chiThucVats = db.ChiThucVats.Include(c => c.HoThucVat);
            return View(chiThucVats.ToList());
        }

        // GET: Admin/ChiThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiThucVat chiThucVat = db.ChiThucVats.Find(id);
            if (chiThucVat == null)
            {
                return HttpNotFound();
            }
            return View(chiThucVat);
        }

        // GET: Admin/ChiThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaHoThucVat = new SelectList(db.HoThucVats, "MaHoThucVat", "TenHoThucVat");
            return View();
        }

        // POST: Admin/ChiThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaChiThucVat,TenChiThucVat,MaHoThucVat")] ChiThucVat chiThucVat)
        {
            if (ModelState.IsValid)
            {
                db.ChiThucVats.Add(chiThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHoThucVat = new SelectList(db.HoThucVats, "MaHoThucVat", "TenHoThucVat", chiThucVat.MaHoThucVat);
            return View(chiThucVat);
        }

        // GET: Admin/ChiThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiThucVat chiThucVat = db.ChiThucVats.Find(id);
            if (chiThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHoThucVat = new SelectList(db.HoThucVats, "MaHoThucVat", "TenHoThucVat", chiThucVat.MaHoThucVat);
            return View(chiThucVat);
        }

        // POST: Admin/ChiThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaChiThucVat,TenChiThucVat,MaHoThucVat")] ChiThucVat chiThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHoThucVat = new SelectList(db.HoThucVats, "MaHoThucVat", "TenHoThucVat", chiThucVat.MaHoThucVat);
            return View(chiThucVat);
        }

        // GET: Admin/ChiThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiThucVat chiThucVat = db.ChiThucVats.Find(id);
            if (chiThucVat == null)
            {
                return HttpNotFound();
            }
            return View(chiThucVat);
        }

        // POST: Admin/ChiThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiThucVat chiThucVat = db.ChiThucVats.Find(id);
            db.ChiThucVats.Remove(chiThucVat);
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
