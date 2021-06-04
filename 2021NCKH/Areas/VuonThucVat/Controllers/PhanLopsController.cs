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
    public class PhanLopsController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        public ActionResult Index()
        {
            var phanLops = db.PhanLops.Include(p => p.Lop1);
            return View(phanLops.ToList());
        }

        // GET: VuonThucVat/PhanLops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLop phanLop = db.PhanLops.Find(id);
            if (phanLop == null)
            {
                return HttpNotFound();
            }
            return View(phanLop);
        }

        // GET: VuonThucVat/PhanLops/Create
        public ActionResult Create()
        {
            ViewBag.Lop = new SelectList(db.Lops, "ID", "TenLop");
            return View();
        }

        // POST: VuonThucVat/PhanLops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenPhanLop,Lop")] PhanLop phanLop)
        {
            if (ModelState.IsValid)
            {
                db.PhanLops.Add(phanLop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Lop = new SelectList(db.Lops, "ID", "TenLop", phanLop.Lop);
            return View(phanLop);
        }

        // GET: VuonThucVat/PhanLops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLop phanLop = db.PhanLops.Find(id);
            if (phanLop == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lop = new SelectList(db.Lops, "ID", "TenLop", phanLop.Lop);
            return View(phanLop);
        }

        // POST: VuonThucVat/PhanLops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenPhanLop,Lop")] PhanLop phanLop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phanLop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Lop = new SelectList(db.Lops, "ID", "TenLop", phanLop.Lop);
            return View(phanLop);
        }

        // GET: VuonThucVat/PhanLops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhanLop phanLop = db.PhanLops.Find(id);
            if (phanLop == null)
            {
                return HttpNotFound();
            }
            return View(phanLop);
        }

        // POST: VuonThucVat/PhanLops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhanLop phanLop = db.PhanLops.Find(id);
            db.PhanLops.Remove(phanLop);
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
