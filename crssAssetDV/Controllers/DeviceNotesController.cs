using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crssAssetDV.Models;

namespace crssAssetDV.Controllers
{
    public class DeviceNotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DeviceNotes
        public ActionResult Index()
        {
            return View(db.DeviceNotes.ToList());
        }

        // GET: DeviceNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceNote deviceNote = db.DeviceNotes.Find(id);
            if (deviceNote == null)
            {
                return HttpNotFound();
            }
            return View(deviceNote);
        }

        // GET: DeviceNotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeviceNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Note")] DeviceNote deviceNote)
        {
            if (ModelState.IsValid)
            {
                db.DeviceNotes.Add(deviceNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deviceNote);
        }

        // GET: DeviceNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceNote deviceNote = db.DeviceNotes.Find(id);
            if (deviceNote == null)
            {
                return HttpNotFound();
            }
            return View(deviceNote);
        }

        // POST: DeviceNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Note")] DeviceNote deviceNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deviceNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deviceNote);
        }

        // GET: DeviceNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeviceNote deviceNote = db.DeviceNotes.Find(id);
            if (deviceNote == null)
            {
                return HttpNotFound();
            }
            return View(deviceNote);
        }

        // POST: DeviceNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DeviceNote deviceNote = db.DeviceNotes.Find(id);
            db.DeviceNotes.Remove(deviceNote);
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
