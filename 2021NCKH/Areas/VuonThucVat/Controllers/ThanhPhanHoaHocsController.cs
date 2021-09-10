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
    public class ThanhPhanHoaHocsController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/ThanhPhanHoaHocs
        public ActionResult Index()
        {
            return View(db.ThanhPhanHoaHocs.ToList());
        }
        public ActionResult CTHH(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPhanHoaHoc thanhPhanHoaHoc = db.ThanhPhanHoaHocs.Find(id);
            if (thanhPhanHoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(thanhPhanHoaHoc);
        }
        public ActionResult Picture(int id)
        {
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + id, "images");
        }
        private const string PICTURE_PATH = "~/images/ThanhPhanHoaHoc/";
        // GET: VuonThucVat/ThanhPhanHoaHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPhanHoaHoc thanhPhanHoaHoc = db.ThanhPhanHoaHocs.Find(id);
            if (thanhPhanHoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(thanhPhanHoaHoc);
        }

        // GET: VuonThucVat/ThanhPhanHoaHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VuonThucVat/ThanhPhanHoaHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ThanhPhanHoaHoc thanhPhanHoaHoc, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        db.ThanhPhanHoaHocs.Add(thanhPhanHoaHoc);
                        db.SaveChanges();

                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + thanhPhanHoaHoc.ID);

                        scope.Complete();
                        return RedirectToAction("Index");
                    }
                }
                else ModelState.AddModelError("", "Picture not found!");
            }
            return View(thanhPhanHoaHoc);
        }

        // GET: VuonThucVat/ThanhPhanHoaHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPhanHoaHoc thanhPhanHoaHoc = db.ThanhPhanHoaHocs.Find(id);
            if (thanhPhanHoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(thanhPhanHoaHoc);
        }

        // POST: VuonThucVat/ThanhPhanHoaHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ThanhPhanHoaHoc thanhPhanHoaHoc, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    db.Entry(thanhPhanHoaHoc).State = EntityState.Modified;
                    db.SaveChanges();

                    if (picture != null)
                    {
                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + thanhPhanHoaHoc.ID);
                    }
                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            return View(thanhPhanHoaHoc);
        }

        // GET: VuonThucVat/ThanhPhanHoaHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPhanHoaHoc thanhPhanHoaHoc = db.ThanhPhanHoaHocs.Find(id);
            if (thanhPhanHoaHoc == null)
            {
                return HttpNotFound();
            }
            return View(thanhPhanHoaHoc);
        }

        // POST: VuonThucVat/ThanhPhanHoaHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var scope = new TransactionScope())
            {
                ThanhPhanHoaHoc thanhphanhoahoc = db.ThanhPhanHoaHocs.Find(id);
                db.ThanhPhanHoaHocs.Remove(thanhphanhoahoc);
                db.SaveChanges();

                var path = Server.MapPath(PICTURE_PATH);
                System.IO.File.Delete(path + thanhphanhoahoc.ID);

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
