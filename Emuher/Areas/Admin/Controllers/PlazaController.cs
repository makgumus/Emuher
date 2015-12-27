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
    public class PlazaController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: Admin/Plaza
        public ActionResult Index()
        {
            ViewBag.aktif3 = "active-menu";
            return View(db.Plaza.ToList());
        }

        // GET: Admin/Plaza/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.aktif3 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaza plaza = db.Plaza.Find(id);
            if (plaza == null)
            {
                return HttpNotFound();
            }
            return View(plaza);
        }

        // GET: Admin/Plaza/Create
        public ActionResult Create()
        {
            ViewBag.aktif3 = "active-menu";
            return View();
        }

        // POST: Admin/Plaza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlazaID,PlazaAdi,Adres,Telefon,Email")] Plaza plaza)
        {
            if (ModelState.IsValid)
            {
                db.Plaza.Add(plaza);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plaza);
        }

        // GET: Admin/Plaza/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aktif3 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaza plaza = db.Plaza.Find(id);
            if (plaza == null)
            {
                return HttpNotFound();
            }
            return View(plaza);
        }

        // POST: Admin/Plaza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlazaID,PlazaAdi,Adres,Telefon,Email")] Plaza plaza)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plaza).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plaza);
        }

        // GET: Admin/Plaza/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.aktif3 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plaza plaza = db.Plaza.Find(id);
            if (plaza == null)
            {
                return HttpNotFound();
            }
            return View(plaza);
        }

        // POST: Admin/Plaza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plaza plaza = db.Plaza.Find(id);
            db.Plaza.Remove(plaza);
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
