using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Emuher.DAL;
using Emuher.Models;
using System.IO;
using PagedList;

namespace Emuher.Areas.Admin.Controllers
{
    [UserAuthorize]
    public class ArabaController : Controller
    {
        private EmuherContext db = new EmuherContext();

        public ActionResult Index(int? page) //Araba indexi
        {
            ViewBag.aktif1 = "active-menu";
            int pageIndex = page ?? 1;
            var result = db.Araba.OrderBy(x => x.ArabaID).ToPagedList(pageIndex,6);
            return View(result);
            //return View(db.Araba.ToList());
        }
        // GET: Araba/Create
        public ActionResult Create()
        {
            ViewBag.aktif1 = "active-menu";
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi");
            return View();
        }

        // POST: Araba/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArabaID,ModelID,Fiyat,Kilometre,SanzimanTipi,YakitTipi,GovdeTipi,MotorGucu")] Araba araba, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                string imageUrl = UploadImage(image);
                araba.Resim = imageUrl;
                db.Araba.Add(araba);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", araba.ModelID);
            return View(araba);
        }

        public string UploadImage(HttpPostedFileBase image)
        {
            var imagePath = Path.Combine(Server.MapPath("~/images/"), image.FileName);
            var imageUrl = Path.Combine("~/images/", image.FileName);
            while (System.IO.File.Exists(imagePath))
            {
                Random rnd = new Random();
                string fileName = Path.GetFileNameWithoutExtension(image.FileName) + "-" + rnd.Next(0, 999) + Path.GetExtension(image.FileName);
                imagePath = Path.Combine(Server.MapPath("~/images/"), fileName);
                imageUrl = Path.Combine("~/images/", fileName);
            }
            image.SaveAs(imagePath);
            return imageUrl;
        }
        public ActionResult Details(int? id)//Araba detayları
        {
            ViewBag.aktif1 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }
        // GET: Araba/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aktif1 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", araba.ModelID);
            return View(araba);
        }

        // POST: Araba/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArabaID,ModelID,Fiyat,Kilometre,SanzimanTipi,YakitTipi,GovdeTipi,MotorGucu")] Araba araba, HttpPostedFileBase image)
        {
            if (image != null)
            {
                string imageUrl = UploadImage(image);
                araba.Resim = imageUrl;
            }
            if (ModelState.IsValid)
            {
                db.Entry(araba).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", araba.ModelID);
            return View(araba);
        }
        // GET: Araba/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.aktif1 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Araba araba = db.Araba.Find(id);
            if (araba == null)
            {
                return HttpNotFound();
            }
            return View(araba);
        }

        // POST: Araba/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Araba araba = db.Araba.Find(id);
            db.Araba.Remove(araba);
            db.SaveChanges();
            return RedirectToAction("Index"); //önceki ->"Index"
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
