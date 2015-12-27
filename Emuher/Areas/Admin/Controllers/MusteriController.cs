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

namespace Emuher.Areas.Admin.Controllers
{
    [UserAuthorize]
    public class MusteriController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: Admin/Musteri
        public ActionResult Index()
        {
            ViewBag.aktif2 = "active-menu";
            return View(db.Musteri.ToList());
        }

        // GET: Admin/Musteri/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.aktif2 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // GET: Admin/Musteri/Create
        public ActionResult Create()
        {
            ViewBag.aktif2 = "active-menu";
            return View();
        }

        // POST: Musteri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MusteriID,Adsoy,KullaniciAdi,Sifre,Telefon,Email,Adres")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                musteri.KayitTarihi = DateTime.Now;
                db.Musteri.Add(musteri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(musteri);
        }

        // GET: Admin/Musteri/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aktif2 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Admin/Musteri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MusteriID,Adsoy,KullaniciAdi,Sifre,Telefon,Email,Adres")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                musteri.KayitTarihi = DateTime.Now;
                db.Entry(musteri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(musteri);
        }

        // GET: Admin/Musteri/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.aktif2 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Musteri musteri = db.Musteri.Find(id);
            if (musteri == null)
            {
                return HttpNotFound();
            }
            return View(musteri);
        }

        // POST: Admin/Musteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Musteri musteri = db.Musteri.Find(id);
            db.Musteri.Remove(musteri);
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
