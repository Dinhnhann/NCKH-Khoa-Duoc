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
    public class BoesController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/Boes
        public ActionResult Index()
        {
            var boes = db.Boes.Include(b => b.PhanLop1);
            return View(boes.ToList());
        }

        // GET: VuonThucVat/Boes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bo bo = db.Boes.Find(id);
            if (bo == null)
            {
                return HttpNotFound();
            }
            return View(bo);
        }

        // GET: VuonThucVat/Boes/Create
        public ActionResult Create()
        {
            ViewBag.PhanLop = new SelectList(db.PhanLops, "ID", "TenPhanLop");
            return View();
        }

        // POST: VuonThucVat/Boes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenBo,PhanLop")] Bo bo)
        {
            if (ModelState.IsValid)
            {
                db.Boes.Add(bo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PhanLop = new SelectList(db.PhanLops, "ID", "TenPhanLop", bo.PhanLop);
            return View(bo);
        }

        // GET: VuonThucVat/Boes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bo bo = db.Boes.Find(id);
            if (bo == null)
            {
                return HttpNotFound();
            }
            ViewBag.PhanLop = new SelectList(db.PhanLops, "ID", "TenPhanLop", bo.PhanLop);
            return View(bo);
        }

        // POST: VuonThucVat/Boes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenBo,PhanLop")] Bo bo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PhanLop = new SelectList(db.PhanLops, "ID", "TenPhanLop", bo.PhanLop);
            return View(bo);
        }

        // GET: VuonThucVat/Boes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bo bo = db.Boes.Find(id);
            if (bo == null)
            {
                return HttpNotFound();
            }
            return View(bo);
        }

        // POST: VuonThucVat/Boes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bo bo = db.Boes.Find(id);
            db.Boes.Remove(bo);
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
