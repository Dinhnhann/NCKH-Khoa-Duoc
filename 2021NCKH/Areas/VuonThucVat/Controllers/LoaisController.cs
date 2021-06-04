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
    public class LoaisController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/Loais
        public ActionResult Index()
        {
            var loais = db.Loais.Include(l => l.Chi1);
            return View(loais.ToList());
        }

        // GET: VuonThucVat/Loais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // GET: VuonThucVat/Loais/Create
        public ActionResult Create()
        {
            ViewBag.Chi = new SelectList(db.Chis, "ID", "TenChi");
            return View();
        }

        // POST: VuonThucVat/Loais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLoai,Chi")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Loais.Add(loai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Chi = new SelectList(db.Chis, "ID", "TenChi", loai.Chi);
            return View(loai);
        }

        // GET: VuonThucVat/Loais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            ViewBag.Chi = new SelectList(db.Chis, "ID", "TenChi", loai.Chi);
            return View(loai);
        }

        // POST: VuonThucVat/Loais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLoai,Chi")] Loai loai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Chi = new SelectList(db.Chis, "ID", "TenChi", loai.Chi);
            return View(loai);
        }

        // GET: VuonThucVat/Loais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Loai loai = db.Loais.Find(id);
            if (loai == null)
            {
                return HttpNotFound();
            }
            return View(loai);
        }

        // POST: VuonThucVat/Loais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loai loai = db.Loais.Find(id);
            db.Loais.Remove(loai);
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
