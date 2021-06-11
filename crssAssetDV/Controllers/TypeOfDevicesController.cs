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
    public class TypeOfDevicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypeOfDevices
        public ActionResult Index()
        {
            return View(db.TypeOfDevices.ToList());
        }

        // GET: TypeOfDevices/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfDevice typeOfDevice = db.TypeOfDevices.Find(id);
            if (typeOfDevice == null)
            {
                return HttpNotFound();
            }
            return View(typeOfDevice);
        }

        // GET: TypeOfDevices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypeOfDevices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] TypeOfDevice typeOfDevice)
        {
            if (ModelState.IsValid)
            {
                db.TypeOfDevices.Add(typeOfDevice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typeOfDevice);
        }

        // GET: TypeOfDevices/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfDevice typeOfDevice = db.TypeOfDevices.Find(id);
            if (typeOfDevice == null)
            {
                return HttpNotFound();
            }
            return View(typeOfDevice);
        }

        // POST: TypeOfDevices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] TypeOfDevice typeOfDevice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typeOfDevice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typeOfDevice);
        }

        // GET: TypeOfDevices/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypeOfDevice typeOfDevice = db.TypeOfDevices.Find(id);
            if (typeOfDevice == null)
            {
                return HttpNotFound();
            }
            return View(typeOfDevice);
        }

        // POST: TypeOfDevices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            TypeOfDevice typeOfDevice = db.TypeOfDevices.Find(id);
            db.TypeOfDevices.Remove(typeOfDevice);
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
