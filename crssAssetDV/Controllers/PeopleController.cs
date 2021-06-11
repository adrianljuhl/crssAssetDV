using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using crssAssetDV.Models;
using System.IO;
using System.Diagnostics;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;
using OfficeOpenXml;
using System.Drawing;
using crssAssetDV.ViewModels;
using Excel = Microsoft.Office.Interop.Excel;

namespace crssAssetDV.Controllers
{
    public class PeopleController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly Devices devices;

        public PeopleController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET: People/Import
        public ActionResult Import()
        {
            return View();
        }



        // GET: People
        public ActionResult Index()
        {

            Process[] excelProcs = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in excelProcs)
            {
                proc.Kill();
            }
            return View(_context.Peoples.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import(HttpPostedFileBase excelFile)
        {


            if (excelFile == null || excelFile.ContentLength == 0)
            {
                ViewBag.Error = "Please select an Excel file. <br />";
                return View("Index");
            }
            else
            {
                string fileExtension = System.IO.Path.GetExtension(excelFile.FileName);
                if (fileExtension.EndsWith(".xls") || fileExtension.EndsWith(".xlsx"))
                {
                    string path = Server.MapPath("~/Files/" + excelFile.FileName);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);
                    excelFile.SaveAs(path);

                    //Read data from Excel File
                    Excel.Application application = new Excel.Application();
                    Excel.Workbook workbook = application.Workbooks.Open(path);
                    Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Excel.Range range = worksheet.UsedRange;
                    List<importModel> importPeoples = new List<importModel>();
                    List<People> listPeoples = new List<People>();

                    for (int row = 2; row < range.Rows.Count; row++)
                    {
                        People p = new People();
                        p.MIS = ((Excel.Range)range.Cells[row, 1]).Text;
                        p.FullName = ((Excel.Range)range.Cells[row, 2]).Text;
                        p.FirstName = ((Excel.Range)range.Cells[row, 3]).Text;
                        p.LastName = ((Excel.Range)range.Cells[row, 4]).Text;
                        p.Email = ((Excel.Range)range.Cells[row, 5]).Text;
                        p.Position = ((Excel.Range)range.Cells[row, 6]).Text;
                        


                        listPeoples.Add(p);
                        _context.Peoples.Add(p);
                        _context.SaveChanges();


                    }

                    ViewBag.ListPeoples = listPeoples;

                    Process[] excelProcs = Process.GetProcessesByName("EXCEL");
                    foreach (Process proc in excelProcs)
                    {
                        proc.Kill();
                    }

                    return View("Success");

                }
                else
                {
                    ViewBag.Error = "File type is incorrect. <br />";
                    Process[] excelProcs = Process.GetProcessesByName("EXCEL");
                    foreach (Process proc in excelProcs)
                    {
                        proc.Kill();
                    }
                    return View("Index");
                }
            }

        }



        // GET: People/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = _context.Peoples.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MIS,FullName,FirstName,LastName,Email,Position,OnLeave,Left")] People people)
        {
            if (ModelState.IsValid)
            {
                _context.Peoples.Add(people);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(people);
        }

        // GET: People/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = _context.Peoples.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MIS,FullName,FirstName,LastName,Email,Position,OnLeave,Left")] People people)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(people).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(people);
        }

        // GET: People/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = _context.Peoples.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            People people = _context.Peoples.Find(id);
            _context.Peoples.Remove(people);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
