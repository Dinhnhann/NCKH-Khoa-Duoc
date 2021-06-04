using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2021NCKH.Areas.VuonThucVat.Data;

namespace _2021NCKH.Areas.VuonThucVat.Controllers
{
    public class LopsController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/Lops
        public ActionResult Index()
        {
            var lops = db.Lops.Include(l => l.Nganh1);
            return View(lops.ToList());
        }

        // GET: VuonThucVat/Lops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // GET: VuonThucVat/Lops/Create
        public ActionResult Create()
        {
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh");
            return View();
        }

        // POST: VuonThucVat/Lops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLop,Nganh")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Lops.Add(lop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", lop.Nganh);
            return View(lop);
        }

        // GET: VuonThucVat/Lops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", lop.Nganh);
            return View(lop);
        }

        // POST: VuonThucVat/Lops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLop,Nganh")] Lop lop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Nganh = new SelectList(db.Nganhs, "ID", "TenNganh", lop.Nganh);
            return View(lop);
        }

        // GET: VuonThucVat/Lops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lop lop = db.Lops.Find(id);
            if (lop == null)
            {
                return HttpNotFound();
            }
            return View(lop);
        }

        // POST: VuonThucVat/Lops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lop lop = db.Lops.Find(id);
            db.Lops.Remove(lop);
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
