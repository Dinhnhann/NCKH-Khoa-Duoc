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
    public class ChisController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/Chis
        public ActionResult Index()
        {
            var chis = db.Chis.Include(c => c.Ho1);
            return View(chis.ToList());
        }

        // GET: VuonThucVat/Chis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chi chi = db.Chis.Find(id);
            if (chi == null)
            {
                return HttpNotFound();
            }
            return View(chi);
        }

        // GET: VuonThucVat/Chis/Create
        public ActionResult Create()
        {
            ViewBag.Ho = new SelectList(db.Hoes, "ID", "TenHo");
            return View();
        }

        // POST: VuonThucVat/Chis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenChi,Ho")] Chi chi)
        {
            if (ModelState.IsValid)
            {
                db.Chis.Add(chi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ho = new SelectList(db.Hoes, "ID", "TenHo", chi.Ho);
            return View(chi);
        }

        // GET: VuonThucVat/Chis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chi chi = db.Chis.Find(id);
            if (chi == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ho = new SelectList(db.Hoes, "ID", "TenHo", chi.Ho);
            return View(chi);
        }

        // POST: VuonThucVat/Chis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenChi,Ho")] Chi chi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ho = new SelectList(db.Hoes, "ID", "TenHo", chi.Ho);
            return View(chi);
        }

        // GET: VuonThucVat/Chis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Chi chi = db.Chis.Find(id);
            if (chi == null)
            {
                return HttpNotFound();
            }
            return View(chi);
        }

        // POST: VuonThucVat/Chis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chi chi = db.Chis.Find(id);
            db.Chis.Remove(chi);
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
