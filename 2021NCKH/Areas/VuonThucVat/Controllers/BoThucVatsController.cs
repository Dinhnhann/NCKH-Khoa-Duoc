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
    public class BoThucVatsController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/BoThucVats
        public ActionResult Index()
        {
            var boThucVats = db.BoThucVats.Include(b => b.PhanLopThucVat);
            return View(boThucVats.ToList());
        }

        // GET: VuonThucVat/BoThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoThucVat boThucVat = db.BoThucVats.Find(id);
            if (boThucVat == null)
            {
                return HttpNotFound();
            }
            return View(boThucVat);
        }

        // GET: VuonThucVat/BoThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaPhanLopThucVat = new SelectList(db.PhanLopThucVats, "MaPhanLopThucVat", "TenPhanLopThucVat");
            return View();
        }

        // POST: VuonThucVat/BoThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BoThucVat boThucVat)
        {
            if (ModelState.IsValid)
            {
                db.BoThucVats.Add(boThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaPhanLopThucVat = new SelectList(db.PhanLopThucVats, "MaPhanLopThucVat", "TenPhanLopThucVat", boThucVat.MaPhanLopThucVat);
            return View(boThucVat);
        }

        // GET: VuonThucVat/BoThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoThucVat boThucVat = db.BoThucVats.Find(id);
            if (boThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaPhanLopThucVat = new SelectList(db.PhanLopThucVats, "MaPhanLopThucVat", "TenPhanLopThucVat", boThucVat.MaPhanLopThucVat);
            return View(boThucVat);
        }

        // POST: VuonThucVat/BoThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaBoThucVat,TenBoThucVat,MaPhanLopThucVat")] BoThucVat boThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaPhanLopThucVat = new SelectList(db.PhanLopThucVats, "MaPhanLopThucVat", "TenPhanLopThucVat", boThucVat.MaPhanLopThucVat);
            return View(boThucVat);
        }

        // GET: VuonThucVat/BoThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BoThucVat boThucVat = db.BoThucVats.Find(id);
            if (boThucVat == null)
            {
                return HttpNotFound();
            }
            return View(boThucVat);
        }

        // POST: VuonThucVat/BoThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BoThucVat boThucVat = db.BoThucVats.Find(id);
            db.BoThucVats.Remove(boThucVat);
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
