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
    public class MarkaController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: Admin/Marka
        public ActionResult Index()
        {
            ViewBag.aktif4 = "active-menu";
            return View(db.Marka.ToList());
        }

        // GET: Admin/Marka/Create
        public ActionResult Create()
        {
            ViewBag.aktif4 = "active-menu";
            return View();
        }

        // POST: Admin/Marka/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MarkaID,MarkaAdi")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                db.Marka.Add(marka);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(marka);
        }

        // GET: Admin/Marka/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aktif4 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = db.Marka.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // POST: Admin/Marka/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MarkaID,MarkaAdi")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marka).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(marka);
        }

        // GET: Admin/Marka/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.aktif4 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Marka marka = db.Marka.Find(id);
            if (marka == null)
            {
                return HttpNotFound();
            }
            return View(marka);
        }

        // POST: Admin/Marka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Marka marka = db.Marka.Find(id);
            db.Marka.Remove(marka);
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
