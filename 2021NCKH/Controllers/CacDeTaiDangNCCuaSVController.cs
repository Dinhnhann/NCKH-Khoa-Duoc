using _2021NCKH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2021NCKH.Controllers
{
    public class CacDeTaiDangNCCuaSVController : Controller
    {
        private NCKHVLUEntities model = new NCKHVLUEntities();

        // GET: CacDeTaiDangNCCuaSV
        public ActionResult Index()
        {
            var nckssv = model.CacDeTaiDangNCCuaSVs.ToList().OrderByDescending(x => x.MaCacDeTaiDangNCCuaSV);
            return View(nckssv);
        }

        public ActionResult Picture(int MaCacDeTaiDangNCCuaSV)
        {
            var path = Server.MapPath(PICTURE_PATH);
            return File(path + MaCacDeTaiDangNCCuaSV, "images");
        }

        private const string PICTURE_PATH = "~/Uploads/ImageHome/";

        public ActionResult Details(int id)
        {
            var nckssv = model.CacDeTaiDangNCCuaSVs.FirstOrDefault(x => x.MaCacDeTaiDangNCCuaSV == id);
            return View(nckssv);
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