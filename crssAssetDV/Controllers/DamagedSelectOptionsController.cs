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
    public class DamagedSelectOptionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DamagedSelectOptions
        public ActionResult Index()
        {
            return View(db.DamagedSelectOptions.ToList());
        }

        // GET: DamagedSelectOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DamagedSelectOption damagedSelectOption = db.DamagedSelectOptions.Find(id);
            if (damagedSelectOption == null)
            {
                return HttpNotFound();
            }
            return View(damagedSelectOption);
        }

        // GET: DamagedSelectOptions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DamagedSelectOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Option")] DamagedSelectOption damagedSelectOption)
        {
            if (ModelState.IsValid)
            {
                db.DamagedSelectOptions.Add(damagedSelectOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(damagedSelectOption);
        }

        // GET: DamagedSelectOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DamagedSelectOption damagedSelectOption = db.DamagedSelectOptions.Find(id);
            if (damagedSelectOption == null)
            {
                return HttpNotFound();
            }
            return View(damagedSelectOption);
        }

        // POST: DamagedSelectOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Option")] DamagedSelectOption damagedSelectOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(damagedSelectOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(damagedSelectOption);
        }

        // GET: DamagedSelectOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DamagedSelectOption damagedSelectOption = db.DamagedSelectOptions.Find(id);
            if (damagedSelectOption == null)
            {
                return HttpNotFound();
            }
            return View(damagedSelectOption);
        }

        // POST: DamagedSelectOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DamagedSelectOption damagedSelectOption = db.DamagedSelectOptions.Find(id);
            db.DamagedSelectOptions.Remove(damagedSelectOption);
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
