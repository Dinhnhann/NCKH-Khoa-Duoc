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
    public class BoThucVatsController : Controller
    {
        private NCKHVLUEntities db = new NCKHVLUEntities();

        // GET: Admin/BoThucVats
        public ActionResult Index()
        {
            var boThucVats = db.BoThucVats.Include(b => b.PhanLopThucVat);
            return View(boThucVats.ToList());
        }

        // GET: Admin/BoThucVats/Details/5
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

        // GET: Admin/BoThucVats/Create
        public ActionResult Create()
        {
            ViewBag.MaPhanLopThucVat = new SelectList(db.PhanLopThucVats, "MaPhanLopThucVat", "TenPhanLopThucVat");
            return View();
        }

        // POST: Admin/BoThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaBoThucVat,TenBoThucVat,MaPhanLopThucVat")] BoThucVat boThucVat)
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

        // GET: Admin/BoThucVats/Edit/5
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

        // POST: Admin/BoThucVats/Edit/5
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

        // GET: Admin/BoThucVats/Delete/5
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

        // POST: Admin/BoThucVats/Delete/5
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
