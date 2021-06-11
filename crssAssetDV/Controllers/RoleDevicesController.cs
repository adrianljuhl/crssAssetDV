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
    public class RoleDevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RoleDevices
        public ActionResult Index()
        {
            return View(db.RoleDevices.ToList());
        }

        // GET: RoleDevices/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDevice roleDevice = db.RoleDevices.Find(id);
            if (roleDevice == null)
            {
                return HttpNotFound();
            }
            return View(roleDevice);
        }

        // GET: RoleDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Role")] RoleDevice roleDevice)
        {
            if (ModelState.IsValid)
            {
                db.RoleDevices.Add(roleDevice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleDevice);
        }

        // GET: RoleDevices/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDevice roleDevice = db.RoleDevices.Find(id);
            if (roleDevice == null)
            {
                return HttpNotFound();
            }
            return View(roleDevice);
        }

        // POST: RoleDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Role")] RoleDevice roleDevice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleDevice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleDevice);
        }

        // GET: RoleDevices/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleDevice roleDevice = db.RoleDevices.Find(id);
            if (roleDevice == null)
            {
                return HttpNotFound();
            }
            return View(roleDevice);
        }

        // POST: RoleDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            RoleDevice roleDevice = db.RoleDevices.Find(id);
            db.RoleDevices.Remove(roleDevice);
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
