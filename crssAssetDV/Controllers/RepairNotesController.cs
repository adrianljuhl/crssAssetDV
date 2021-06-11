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
    public class RepairNotesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RepairNotes
        public ActionResult Index()
        {
            var repairNotes = db.RepairNotes.Include(r => r.Device).Include(r => r.Loan).Include(r => r.People).Include(r => r.RepairType);
            return View(repairNotes.ToList());
        }

        // GET: RepairNotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairNote repairNote = db.RepairNotes.Find(id);
            if (repairNote == null)
            {
                return HttpNotFound();
            }
            return View(repairNote);
        }

        // GET: RepairNotes/Create
        public ActionResult Create()
        {
            ViewBag.DeviceId = new SelectList(db.Devices, "Id", "Brand");
            ViewBag.LoanId = new SelectList(db.Loans, "Id", "LoanType");
            ViewBag.PeopleId = new SelectList(db.Peoples, "Id", "MIS");
            ViewBag.RepairTypeId = new SelectList(db.RepairTypes, "Id", "Repair");
            return View();
        }

        // POST: RepairNotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RepairDate,DeviceId,PeopleId,LoanNote,LoanId,RepairTypeId,RepairCost")] RepairNote repairNote)
        {
            if (ModelState.IsValid)
            {
                db.RepairNotes.Add(repairNote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DeviceId = new SelectList(db.Devices, "Id", "Brand", repairNote.DeviceId);
            ViewBag.LoanId = new SelectList(db.Loans, "Id", "LoanType", repairNote.RepairTypeId);
            ViewBag.PeopleId = new SelectList(db.Peoples, "Id", "MIS", repairNote.PeopleId);
            ViewBag.RepairTypeId = new SelectList(db.RepairTypes, "Id", "Repair", repairNote.RepairTypeId);
            return View(repairNote);
        }

        // GET: RepairNotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairNote repairNote = db.RepairNotes.Find(id);
            if (repairNote == null)
            {
                return HttpNotFound();
            }
            ViewBag.DeviceId = new SelectList(db.Devices, "Id", "Brand", repairNote.DeviceId);
            ViewBag.LoanId = new SelectList(db.Loans, "Id", "LoanType", repairNote.RepairTypeId);
            ViewBag.PeopleId = new SelectList(db.Peoples, "Id", "MIS", repairNote.PeopleId);
            ViewBag.RepairTypeId = new SelectList(db.RepairTypes, "Id", "Repair", repairNote.RepairTypeId);
            return View(repairNote);
        }

        // POST: RepairNotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RepairDate,DeviceId,PeopleId,LoanNote,LoanId,RepairTypeId,RepairCost")] RepairNote repairNote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairNote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DeviceId = new SelectList(db.Devices, "Id", "Brand", repairNote.DeviceId);
            ViewBag.LoanId = new SelectList(db.Loans, "Id", "LoanType", repairNote.RepairTypeId);
            ViewBag.PeopleId = new SelectList(db.Peoples, "Id", "MIS", repairNote.PeopleId);
            ViewBag.RepairTypeId = new SelectList(db.RepairTypes, "Id", "Repair", repairNote.RepairTypeId);
            return View(repairNote);
        }

        // GET: RepairNotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepairNote repairNote = db.RepairNotes.Find(id);
            if (repairNote == null)
            {
                return HttpNotFound();
            }
            return View(repairNote);
        }

        // POST: RepairNotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepairNote repairNote = db.RepairNotes.Find(id);
            db.RepairNotes.Remove(repairNote);
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
