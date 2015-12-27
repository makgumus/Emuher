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
    public class ModelController : Controller
    {
        private EmuherContext db = new EmuherContext();

        // GET: Admin/Model
        public ActionResult Index()
        {
            ViewBag.aktif5 = "active-menu";
            var model = db.Model.Include(m => m.Marka);
            return View(model.ToList());
        }

        // GET: Admin/Model/Create
        public ActionResult Create()
        {
            ViewBag.aktif5 = "active-menu";
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi");
            return View();
        }

        // POST: Admin/Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ModelID,MarkaID,ModelAdi")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Model.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi", model.MarkaID);
            return View(model);
        }

        // GET: Admin/Model/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.aktif5 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi", model.MarkaID);
            return View(model);
        }

        // POST: Admin/Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ModelID,MarkaID,ModelAdi")] Model model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarkaID = new SelectList(db.Marka, "MarkaID", "MarkaAdi", model.MarkaID);
            return View(model);
        }

        // GET: Admin/Model/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.aktif5 = "active-menu";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Model model = db.Model.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Model model = db.Model.Find(id);
            db.Model.Remove(model);
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
