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
    public class AdminController : Controller
    {
        private NCKHVLUEntities1 db = new NCKHVLUEntities1();

        // GET: VuonThucVat/ThucVat
        public ActionResult Index()
        {
            var thucVats = db.ThucVats.Include(t => t.LoaiThucVat);
            ViewData["CTHH"] = db.ChiTietCTHHs.ToList();
            return View(thucVats.ToList());
        }
        public ActionResult ThemCTHH(int? id)
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
            ViewData["id"] = id;
            var tphh = db.ThanhPhanHoaHocs.ToList();
            ViewData["CTHH"] = db.ChiTietCTHHs.ToList();
            return View(tphh);
        }
        [HttpPost]
        public ActionResult ThemCTHH(int idhh, int idtv)
        {
            ThucVat thucVat = db.ThucVats.Find(idtv);
            if (thucVat == null)
            {
                return HttpNotFound();
            }
            ThanhPhanHoaHoc tphh = db.ThanhPhanHoaHocs.Find(idhh);
            if (tphh == null)
            {
                return HttpNotFound();
            }
            ChiTietCTHH ct = new ChiTietCTHH();
            ct.ThucVat1 = thucVat;
            ct.ThanhPhanHoaHoc = tphh;
            db.ChiTietCTHHs.Add(ct);
            db.SaveChanges();
            ViewData["CTHH"] = db.ChiTietCTHHs.ToList();
            return RedirectToAction("ThemCTHH", new { id = idtv });
        }
        [HttpPost]
        public ActionResult XoaCTHH(int idhh, int idtv)
        {
            ThucVat thucVat = db.ThucVats.Find(idtv);
            if (thucVat == null)
            {
                return HttpNotFound();
            }
            ThanhPhanHoaHoc tphh = db.ThanhPhanHoaHocs.Find(idhh);
            if (tphh == null)
            {
                return HttpNotFound();
            }
            var model = db.ChiTietCTHHs.ToList();
            //model = model.Where(p => p.TenVietNam.ToLower().Contains(keyword.ToLower())).ToList();
            model = (from s in model
                     where s.ThanhPhanHoaHoc.ID.ToString().Contains(idhh.ToString())
                     && s.ThucVat1.MaCay.ToString().Contains(idtv.ToString())
                     select s).ToList();
            foreach (var item in model)
            {
                ChiTietCTHH cthh = db.ChiTietCTHHs.Find(item.ID);
                db.ChiTietCTHHs.Remove(cthh);
                db.SaveChanges();
            }
            ViewData["CTHH"] = db.ChiTietCTHHs.ToList();
            return RedirectToAction("ThemCTHH", new { id = idtv });
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
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVatDuoi");
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
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVatDuoi", thucVat.MaLoaiThucVat);
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
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVatDuoi", thucVat.MaLoaiThucVat);
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
            ViewBag.MaLoaiThucVat = new SelectList(db.LoaiThucVats, "MaLoaiThucVat", "TenLoaiThucVatDuoi", thucVat.MaLoaiThucVat);
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
