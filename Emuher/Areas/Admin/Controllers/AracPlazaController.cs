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
    public class AracPlazaController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: Admin/AracPlaza
        public ActionResult Index()
        {
            ViewBag.aktif6 = "active-menu";
            var aracPlaza = db.AracPlaza.Include(a => a.Model).Include(a => a.Plaza);
            return View(aracPlaza.ToList());
        }

        // GET: Admin/AracPlaza/Create
        public ActionResult Create()
        {
            ViewBag.aktif6 = "active-menu";
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi");
            ViewBag.PlazaID = new SelectList(db.Plaza, "PlazaID", "PlazaAdi");
            return View();
        }

        // POST: Admin/AracPlaza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracPlazaID,ModelID,PlazaID,Stok")] AracPlaza aracPlaza)
        {
            if (ModelState.IsValid)
            {
                db.AracPlaza.Add(aracPlaza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", aracPlaza.ModelID);
            ViewBag.PlazaID = new SelectList(db.Plaza, "PlazaID", "PlazaAdi", aracPlaza.PlazaID);
            return View(aracPlaza);
        }

        // GET: Admin/AracPlaza/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aktif6 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracPlaza aracPlaza = db.AracPlaza.Find(id);
            if (aracPlaza == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", aracPlaza.ModelID);
            ViewBag.PlazaID = new SelectList(db.Plaza, "PlazaID", "PlazaAdi", aracPlaza.PlazaID);
            return View(aracPlaza);
        }

        // POST: Admin/AracPlaza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracPlazaID,ModelID,PlazaID,Stok")] AracPlaza aracPlaza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracPlaza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", aracPlaza.ModelID);
            ViewBag.PlazaID = new SelectList(db.Plaza, "PlazaID", "PlazaAdi", aracPlaza.PlazaID);
            return View(aracPlaza);
        }

        // GET: Admin/AracPlaza/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.aktif6 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracPlaza aracPlaza = db.AracPlaza.Find(id);
            if (aracPlaza == null)
            {
                return HttpNotFound();
            }
            return View(aracPlaza);
        }

        // POST: Admin/AracPlaza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AracPlaza aracPlaza = db.AracPlaza.Find(id);
            db.AracPlaza.Remove(aracPlaza);
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
