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
    public class ChiThucVatsController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/ChiThucVats
        public ActionResult Index()
        {
            var chiThucVats = db.ChiThucVats.Include(c => c.HoThucVat);
            return View(chiThucVats.ToList());
        }

        // GET: VuonThucVat/ChiThucVats/Details/5
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

        // GET: VuonThucVat/ChiThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaHoThucVat = new SelectList(db.HoThucVats, "MaHoThucVat", "TenHoThucVat");
            return View();
        }

        // POST: VuonThucVat/ChiThucVats/Create
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

        // GET: VuonThucVat/ChiThucVats/Edit/5
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

        // POST: VuonThucVat/ChiThucVats/Edit/5
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

        // GET: VuonThucVat/ChiThucVats/Delete/5
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

        // POST: VuonThucVat/ChiThucVats/Delete/5
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
