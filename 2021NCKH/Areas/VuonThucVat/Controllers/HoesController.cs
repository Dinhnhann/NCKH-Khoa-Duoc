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
    public class HoesController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/Hoes
        public ActionResult Index()
        {
            var hoes = db.Hoes.Include(h => h.Bo1);
            return View(hoes.ToList());
        }

        // GET: VuonThucVat/Hoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ho ho = db.Hoes.Find(id);
            if (ho == null)
            {
                return HttpNotFound();
            }
            return View(ho);
        }

        // GET: VuonThucVat/Hoes/Create
        public ActionResult Create()
        {
            ViewBag.Bo = new SelectList(db.Boes, "ID", "TenBo");
            return View();
        }

        // POST: VuonThucVat/Hoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenHo,Bo")] Ho ho)
        {
            if (ModelState.IsValid)
            {
                db.Hoes.Add(ho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bo = new SelectList(db.Boes, "ID", "TenBo", ho.Bo);
            return View(ho);
        }

        // GET: VuonThucVat/Hoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ho ho = db.Hoes.Find(id);
            if (ho == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bo = new SelectList(db.Boes, "ID", "TenBo", ho.Bo);
            return View(ho);
        }

        // POST: VuonThucVat/Hoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenHo,Bo")] Ho ho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bo = new SelectList(db.Boes, "ID", "TenBo", ho.Bo);
            return View(ho);
        }

        // GET: VuonThucVat/Hoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ho ho = db.Hoes.Find(id);
            if (ho == null)
            {
                return HttpNotFound();
            }
            return View(ho);
        }

        // POST: VuonThucVat/Hoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ho ho = db.Hoes.Find(id);
            db.Hoes.Remove(ho);
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
