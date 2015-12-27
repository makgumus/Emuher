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

namespace Emuher.Controllers
{
    public class AracRenkController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: AracRenk
        public ActionResult Index()
        {
            var aracRenk = db.AracRenk.Include(a => a.Model).Include(a => a.Renk);
            return View(aracRenk.ToList());
        }

        // GET: AracRenk/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracRenk aracRenk = db.AracRenk.Find(id);
            if (aracRenk == null)
            {
                return HttpNotFound();
            }
            return View(aracRenk);
        }

        // GET: AracRenk/Create
        public ActionResult Create()
        {
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi");
            ViewBag.RenkID = new SelectList(db.Renk, "RenkID", "RenkAdi");
            return View();
        }

        // POST: AracRenk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AracRenkID,ModelID,RenkID")] AracRenk aracRenk)
        {
            if (ModelState.IsValid)
            {
                db.AracRenk.Add(aracRenk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", aracRenk.ModelID);
            ViewBag.RenkID = new SelectList(db.Renk, "RenkID", "RenkAdi", aracRenk.RenkID);
            return View(aracRenk);
        }

        // GET: AracRenk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracRenk aracRenk = db.AracRenk.Find(id);
            if (aracRenk == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", aracRenk.ModelID);
            ViewBag.RenkID = new SelectList(db.Renk, "RenkID", "RenkAdi", aracRenk.RenkID);
            return View(aracRenk);
        }

        // POST: AracRenk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AracRenkID,ModelID,RenkID")] AracRenk aracRenk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aracRenk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ModelID = new SelectList(db.Model, "ModelID", "ModelAdi", aracRenk.ModelID);
            ViewBag.RenkID = new SelectList(db.Renk, "RenkID", "RenkAdi", aracRenk.RenkID);
            return View(aracRenk);
        }

        // GET: AracRenk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AracRenk aracRenk = db.AracRenk.Find(id);
            if (aracRenk == null)
            {
                return HttpNotFound();
            }
            return View(aracRenk);
        }

        // POST: AracRenk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AracRenk aracRenk = db.AracRenk.Find(id);
            db.AracRenk.Remove(aracRenk);
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
