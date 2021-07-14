using _2021NCKH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Areas.Admin.Controllers
{
    public class CacBoMonController : BaseController
    {
       private NCKHVLUEntities model = new NCKHVLUEntities();
        // GET: Admin/CacBoMon
        public ActionResult Index()
        {
            var cacbomon = model.CacBoMons.OrderByDescending(x => x.MaCacBoMon).ToList();
            return View(cacbomon);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //tạo kèm picture
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CacBoMon cacbomon)
        {
            var cbm = new CacBoMon();
            cbm.TenCacBoMon = cacbomon.TenCacBoMon;
            cbm.NDTomTatCacBoMon = cacbomon.NDTomTatCacBoMon;
            cbm.NDChiTietCacBoMon = cacbomon.NDChiTietCacBoMon;
            model.CacBoMons.Add(cbm);
            model.SaveChanges();
            return RedirectToAction("Index");

        }
       

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cbm = model.CacBoMons.FirstOrDefault(x => x.MaCacBoMon == id);
            return View(cbm);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CacBoMon cacbomon)
        {
            var cbm = model.CacBoMons.FirstOrDefault(x => x.MaCacBoMon == id);
            cbm.TenCacBoMon = cacbomon.TenCacBoMon;
            cbm.NDTomTatCacBoMon = cacbomon.NDTomTatCacBoMon;
            cbm.NDChiTietCacBoMon = cacbomon.NDChiTietCacBoMon;
            model.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var cbm = model.CacBoMons.FirstOrDefault(x => x.MaCacBoMon == id);
            return View(cbm);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            var cbm = model.CacBoMons.FirstOrDefault(x => x.MaCacBoMon == id);
            model.CacBoMons.Remove(cbm);
            model.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                model.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}