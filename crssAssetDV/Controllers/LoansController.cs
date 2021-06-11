using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crssAssetDV.Models;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using OfficeOpenXml;

using System.Drawing;
using crssAssetDV.ViewModels;


namespace crssAssetDV.Controllers
{
    public class LoansController : Controller
    {

        private readonly ApplicationDbContext _context;
        //private readonly Devices devices;

        public LoansController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: LoansController
        public ActionResult Index()
        {
            return View();

        }

        // GET: LoansController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var loans = _context.Loans
                    //.Include(t => t.LoanType)
                    .Include(r => r.People)
                    .Include(d => d.Device)
                    .SingleOrDefault(p => p.Id == id);


            if (loans == null)
            {
                return HttpNotFound();
            }
            return View(loans);



        }

        // GET: Loans/New
        public ActionResult New()
        {
            //var devices = _context.Devices;
            var loanTypes = _context.LoanTypes.ToList();
            var people = _context.Peoples.ToList();
            var devices = _context.Devices.ToList();
            var viewModel = new LoanFormViewModel

            {
                Loan = new Loan(),
                Devices = devices,
                LoanTypes = loanTypes,
                Peoples = people,
                                
            };

            return View("LoanForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loan)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoanFormViewModel
                {
                    Loan = loan,
                    LoanTypes = _context.LoanTypes.ToList(),
                    Peoples = _context.Peoples.ToList(),
                    Devices = _context.Devices.ToList()
            };

                return View("LoanFormViewModel", viewModel);
            }
                if (loan.Id == 0)
                _context.Loans.Add(loan);
                else
                {
                    var loansInDb = _context.Loans.Single(d => d.Id == loan.Id);

               
                    loansInDb.PeopleId = loan.PeopleId;
                    loansInDb.DeviceId = loan.DeviceId;
                    loansInDb.LoanTypeId = loan.LoanTypeId;
                    loansInDb.Classroom = loan.Classroom;
                    loansInDb.StartDate = loan.StartDate;
                    loansInDb.SpecialNote = loan.SpecialNote;
                    loansInDb.SuppliedCable = loan.SuppliedCable;
                    loansInDb.SuppliedCover = loan.SuppliedCover;
                    loansInDb.SuppliedPowerBlock = loan.SuppliedPowerBlock;
                    loansInDb.OampsUpdated = loan.OampsUpdated;
                    loansInDb.IntuneUpdated = loan.IntuneUpdated;
                    loansInDb.EdquipSigned = loan.EdquipSigned;
                    loansInDb.Current = loan.Current;
                    loansInDb.ReturnDate = loan.ReturnDate;


            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Loans");
        }
        // GET: Loans/Edit/5
        public ActionResult Edit(int id)
        {
            var loans = _context.Loans
                    //.Include(t => t.LoanType)
                    .Include(r => r.People)
                    .Include(d => d.Device)
                    .SingleOrDefault(t => t.Id == id);

            if (loans == null)
                return HttpNotFound();

            var viewModel = new LoanFormViewModel
            {
                Loan = loans,
                LoanTypes = _context.LoanTypes.ToList(),
                Peoples = _context.Peoples.ToList(),
                Devices = _context.Devices.ToList()

            };
            return View("LoanForm", viewModel);

        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Loan loans = _context.Loans.Find(id);
            _context.Loans.Remove(loans);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

