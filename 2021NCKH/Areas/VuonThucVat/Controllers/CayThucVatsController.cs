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
    public class CayThucVatsController : Controller
    {
        private KHOADUOCEntities2 db = new KHOADUOCEntities2();

        // GET: VuonThucVat/CayThucVats
        public ActionResult Index()
        {
            var cayThucVats = db.CayThucVats.Include(c => c.Loai1);
            return View(cayThucVats.ToList());
        }
        public ActionResult Index2()
        {
            var cayThucVats = db.CayThucVats.Include(c => c.Loai1);
            return View(cayThucVats.ToList());
        }
        // GET: VuonThucVat/CayThucVats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CayThucVat cayThucVat = db.CayThucVats.Find(id);
            if (cayThucVat == null)
            {
                return HttpNotFound();
            }
            return View(cayThucVat);
        }

        // GET: VuonThucVat/CayThucVats/Create
        public ActionResult Create()
        {
            ViewBag.Loai = new SelectList(db.Loais, "ID", "TenLoai");
            return View();
        }

        // POST: VuonThucVat/CayThucVats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenVietNam,TenKhoaHoc,MoTa,BoPhanDung,ThanhPhanHoaHoc,TacDungDuocLy,CongDung,CachDung,LieuDung,Loai")] CayThucVat cayThucVat)
        {
            if (ModelState.IsValid)
            {
                db.CayThucVats.Add(cayThucVat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Loai = new SelectList(db.Loais, "ID", "TenLoai", cayThucVat.Loai);
            return View(cayThucVat);
        }

        // GET: VuonThucVat/CayThucVats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CayThucVat cayThucVat = db.CayThucVats.Find(id);
            if (cayThucVat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Loai = new SelectList(db.Loais, "ID", "TenLoai", cayThucVat.Loai);
            return View(cayThucVat);
        }

        // POST: VuonThucVat/CayThucVats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenVietNam,TenKhoaHoc,MoTa,BoPhanDung,ThanhPhanHoaHoc,TacDungDuocLy,CongDung,CachDung,LieuDung,Loai")] CayThucVat cayThucVat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cayThucVat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Loai = new SelectList(db.Loais, "ID", "TenLoai", cayThucVat.Loai);
            return View(cayThucVat);
        }

        // GET: VuonThucVat/CayThucVats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CayThucVat cayThucVat = db.CayThucVats.Find(id);
            if (cayThucVat == null)
            {
                return HttpNotFound();
            }
            return View(cayThucVat);
        }

        // POST: VuonThucVat/CayThucVats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CayThucVat cayThucVat = db.CayThucVats.Find(id);
            db.CayThucVats.Remove(cayThucVat);
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
