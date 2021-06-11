﻿using System;
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
    public class LoanNotesController : Controller
    {

        private readonly ApplicationDbContext _context;
        //private readonly Devices devices;

        public LoanNotesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: LoanNotesController
        public ActionResult Index()
        {
            return View();

        }

        // GET: LoanNotesController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var loanNotes = _context.LoanNotes
                    
                    .Include(r => r.Loan)                  
                    .SingleOrDefault(p => p.Id == id);



            if (loanNotes == null)
            {
                return HttpNotFound();
            }
            return View(loanNotes);
        }

        // GET: LoanNotes/New
        public ActionResult New()
        {
            
            var loans = _context.Loans.ToList();
            var viewModel = new LoanNoteFormViewModel

            {
                LoanNote = new LoanNote(),
                Loans = loans,

            };

            return View("LoanNoteForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoanNote loanNote)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new LoanNoteFormViewModel
                {
                    LoanNote = loanNote,
                    Loans = _context.Loans.ToList()

                };

                return View("LoanNoteFormViewModel", viewModel);
            }
            if (loanNote.Id == 0)
                _context.LoanNotes.Add(loanNote);
            else
            {
                var loansInDb = _context.LoanNotes.Single(d => d.Id == loanNote.Id);
                loansInDb.Note = loanNote.Note;
                loansInDb.LoanId = loanNote.LoanId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "LoanNotes");
        }
        // GET: Loans/Edit/5
        public ActionResult Edit(int id)
        {
            var loanNote = _context.LoanNotes
                    
                    .Include(r => r.Loan)                    
                    .SingleOrDefault(t => t.Id == id);

            if (loanNote == null)
                return HttpNotFound();

            var viewModel = new LoanNoteFormViewModel
            {
                LoanNote = loanNote,
                Loans = _context.Loans.ToList()


            };
            return View("LoanNoteForm", viewModel);

        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoanNote loanNotes = _context.LoanNotes.Find(id);
            _context.LoanNotes.Remove(loanNotes);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

