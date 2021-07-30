using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using _2021NCKH.Models;

namespace _2021NCKH.Areas.VuonThucVat.Controllers
{
    public class ThucVatController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/ThucVat
        public ActionResult Index()
        {
            var thucVats = db.ThucVats.Include(t => t.LoaiThucVat);
            return View(thucVats.ToList());
        }

        // GET: VuonThucVat/ThucVat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucVat thucVat = db.ThucVats.Find(id);
            if (thucVat == null)
            {
                return HttpNotFound();
            }
            return View(thucVat);
        }
        public ActionResult Picture(int id)
        {
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + id, "images");
        }
        private const string PICTURE_PATH = "~/images/ThucVat/";
        // GET: VuonThucVat/ThucVat/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat");
            return View();
        }

        // POST: VuonThucVat/ThucVat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThucVat thucVat, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        db.ThucVats.Add(thucVat);
                        db.SaveChanges();

                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + thucVat.MaCay);

                        scope.Complete();
                        return RedirectToAction("Index");
                    }
                }
            }
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat", thucVat.MaLoaiThucVat);
            return View(thucVat);
        }

        // GET: VuonThucVat/ThucVat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucVat thucVat = db.ThucVats.Find(id);
            if (thucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat", thucVat.MaLoaiThucVat);
            return View(thucVat);
        }

        // POST: VuonThucVat/ThucVat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThucVat thucVat, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    db.Entry(thucVat).State = EntityState.Modified;
                    db.SaveChanges();

                    if (picture != null)
                    {
                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + thucVat.MaCay);
                    }
                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVat", thucVat.MaLoaiThucVat);
            return View(thucVat);
        }

        // GET: VuonThucVat/ThucVat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThucVat thucVat = db.ThucVats.Find(id);
            if (thucVat == null)
            {
                return HttpNotFound();
            }
            return View(thucVat);
        }

        // POST: VuonThucVat/ThucVat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var scope = new TransactionScope())
            {
                ThucVat thucVat = db.ThucVats.Find(id);
                db.ThucVats.Remove(thucVat);
                db.SaveChanges();

                var path = Server.MapPath(PICTURE_PATH);
                System.IO.File.Delete(path + thucVat.MaCay);

                scope.Complete();
                return RedirectToAction("Index");
            }
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
