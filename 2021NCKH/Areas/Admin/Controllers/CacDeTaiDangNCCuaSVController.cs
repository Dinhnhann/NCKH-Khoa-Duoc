using _2021NCKH.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Areas.Admin.Controllers
{
    public class CacDeTaiDangNCCuaSVController : BaseController
    {
        private NCKHVLUEntities model = new NCKHVLUEntities();

        // GET: Admin/CacDeTaiDangNCCuaSV
        public ActionResult Index()
        {
            var nckhsv = model.CacDeTaiDangNCCuaSVs.OrderByDescending(x => x.MaCacDeTaiDangNCCuaSV).ToList();
            return View(nckhsv);
        }

        public ActionResult Picture(int MaCacDeTaiDangNCCuaSV)
        {
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + MaCacDeTaiDangNCCuaSV, "images");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //tạo kèm picture
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CacDeTaiDangNCCuaSV nckhsv, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                if (picture != null)
                {
                    using (var scope = new TransactionScope())
                    {
                        model.CacDeTaiDangNCCuaSVs.Add(nckhsv);
                        model.SaveChanges();

                        // store picture
                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + nckhsv.MaCacDeTaiDangNCCuaSV);

                        scope.Complete();
                        return RedirectToAction("Index");
                    }
                }
                else ModelState.AddModelError("", "Picture not found!");
            }
            return View(nckhsv);
        }

        // đường dẫn lưu
        private const string PICTURE_PATH = "~/Uploads/ImageHome/";

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var nckhsv = model.CacDeTaiDangNCCuaSVs.Find(id);
            if (nckhsv == null)
            {
                return HttpNotFound();
            }
            return View(nckhsv);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CacDeTaiDangNCCuaSV nckhsv, HttpPostedFileBase picture)
        {
            if (ModelState.IsValid)
            {
                using (var scope = new TransactionScope())
                {
                    model.Entry(nckhsv).State = EntityState.Modified;
                    model.SaveChanges();

                    if (picture != null)
                    {
                        var path = Server.MapPath(PICTURE_PATH);
                        picture.SaveAs(path + nckhsv.MaCacDeTaiDangNCCuaSV);
                    }

                    scope.Complete();
                    return RedirectToAction("Index");
                }
            }
            return View(nckhsv);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var nckhsv = model.CacDeTaiDangNCCuaSVs.Find(id);
            if (nckhsv == null)
            {
                return HttpNotFound();
            }
            return View(nckhsv);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var scope = new TransactionScope())
            {
                var nckhsv = model.CacDeTaiDangNCCuaSVs.Find(id);
                model.CacDeTaiDangNCCuaSVs.Remove(nckhsv);
                model.SaveChanges();

                var path = Server.MapPath(PICTURE_PATH);
                System.IO.File.Delete(path + nckhsv.MaCacDeTaiDangNCCuaSV);

                scope.Complete();
                return RedirectToAction("Index");
            }
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