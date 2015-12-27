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
    public class RenkController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: Admin/Renk
        public ActionResult Index()
        {
            return View(db.Renk.ToList());
        }
       
        // GET: Admin/Renk/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Renk/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RenkID,RenkAdi")] Renk renk)
        {
            if (ModelState.IsValid)
            {
                db.Renk.Add(renk);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(renk);
        }

        // GET: Admin/Renk/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renk renk = db.Renk.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        // POST: Admin/Renk/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RenkID,RenkAdi")] Renk renk)
        {
            if (ModelState.IsValid)
            {
                db.Entry(renk).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renk);
        }

        // GET: Admin/Renk/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Renk renk = db.Renk.Find(id);
            if (renk == null)
            {
                return HttpNotFound();
            }
            return View(renk);
        }

        // POST: Admin/Renk/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Renk renk = db.Renk.Find(id);
            db.Renk.Remove(renk);
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
