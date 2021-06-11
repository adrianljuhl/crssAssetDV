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
using OfficeOpenXml.Style;
using System.Drawing;

namespace crssAssetDV.Controllers
{
    public class DevicesController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationDbContext _context;
        public DevicesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {           
             _context.Dispose();     
        }

        // GET: Devices
        public ActionResult Index()
        {
            var devices = _context.Devices.Include(c => c.TypeOfDevice).ToList();
            return View(devices);
        }

        // GET: Devices/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices devices = _context.Devices.Find(id);
            if (devices == null)    
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // GET: Devices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,Model,Description,Edquip,Serial,SpecialisedDevice,BuildingLocation,HasPowerSupply,HasPowerCable,HasCover,Accessories,Damaged,WriteOff")] Devices devices)
        {
            if (ModelState.IsValid)
            {
                _context.Devices.Add(devices);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(devices);
        }

        // GET: Devices/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices devices = _context.Devices.Find(id);
            if (devices == null)
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,Model,Description,Edquip,Serial,SpecialisedDevice,BuildingLocation,HasPowerSupply,HasPowerCable,HasCover,Accessories,Damaged,WriteOff")] Devices devices)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(devices).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(devices);
        }

        // GET: Devices/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Devices devices = _context.Devices.Find(id);
            if (devices == null)
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Devices devices = _context.Devices.Find(id);
            _context.Devices.Remove(devices);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public void ExportContentToCSV()
        {
            StringWriter strw = new StringWriter();
            strw.WriteLine("\"Brand\",\"Model\",\"Description\",\"Edquip\",\"Serial\",\"Type\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition",
                                string.Format("attachment;filename=Devices_{0}.csv", DateTime.Now));
            Response.ContentType = "text/csv";

            var listDevices = _context.Devices.OrderBy(x => x.Edquip).ToList();
            foreach (var listItem in listDevices)
            {
                strw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\"",
                                             listItem.Brand, listItem.Model, listItem.Description, listItem.Edquip, listItem.Serial, listItem.TypeOfDevice));
            }
            Response.Write(strw.ToString());
            Response.End();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _context.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //NativeExport
        public ActionResult NativeExport()
        {
            List<DevicesViewModel> devlist = _context.Devices.Select(x => new DevicesViewModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Description = x.Description,
                Edquip = x.Edquip,
                Serial = x.Serial,
                SpecialisedDevice = x.SpecialisedDevice,
                BuildingLocation = x.BuildingLocation,
                HasPowerSupply = x.HasPowerSupply,
                HasPowerCable = x.HasPowerCable,
                HasCover = x.HasCover,
                Accessories = x.Accessories,
                DeviceNotes = x.DeviceNotes,
                WriteOff = x.WriteOff,
                TypeOfDevice = x.TypeOfDevice.Type,
            }).ToList();

            return View(devlist);
        }

        public void ExportToNative()
        {
            List<DevicesViewModel> devlist = _context.Devices.Select(x => new DevicesViewModel
            {
                Id = x.Id,
                Brand = x.Brand,
                Model = x.Model,
                Description = x.Description,
                Edquip = x.Edquip,
                Serial = x.Serial,
                SpecialisedDevice = x.SpecialisedDevice,
                BuildingLocation = x.BuildingLocation,
                HasPowerSupply = x.HasPowerSupply,
                HasPowerCable = x.HasPowerCable,
                HasCover = x.HasCover,
                Accessories = x.Accessories,               
                DeviceNotes = x.DeviceNotes,
                WriteOff = x.WriteOff,
                TypeOfDevice = x.TypeOfDevice.Type,
            }).ToList();

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "CRSS Asset Tracker";
            ws.Cells["A2"].Value = "Report";

            ws.Cells["B2"].Value = "Master Export";

            ws.Cells["A3"].Value = "Date";
            ws.Cells["B3"].Value = string.Format("{0:dd MMM yyyy} at {0:H mm tt}", DateTimeOffset.Now);

            ws.Cells["A6"].Value = "Id";
            ws.Cells["B6"].Value = "Brand";
            ws.Cells["C6"].Value = "Model";
            //ws.Cells["D6"].Value = "DeviceTypeId";
            ws.Cells["D6"].Value = "Description";
            ws.Cells["E6"].Value = "Edquip";
            ws.Cells["F6"].Value = "Serial";
            ws.Cells["G6"].Value = "SpecialisedDevice";
            ws.Cells["H6"].Value = "BuildingLocation";
            ws.Cells["I6"].Value = "HasPowerSupply";
            ws.Cells["J6"].Value = "HasPowerCable";
            ws.Cells["K6"].Value = "HasCover";
            ws.Cells["L6"].Value = "Accessories";
            //ws.Cells["M6"].Value = "RepairTypes";
            ws.Cells["M6"].Value = "DeviceNotes";
            ws.Cells["N6"].Value = "WriteOff";
            ws.Cells["O6"].Value = "TypeOfDevice";

            int rowstart = 7;
            foreach (var item in devlist)
            {
                if (item.WriteOff == true)
                {
                    ws.Row(rowstart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Row(rowstart).Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml(string.Format("pink")));

                }

                ws.Cells[string.Format("A{0}", rowstart)].Value = item.Id;
                ws.Cells[string.Format("B{0}", rowstart)].Value = item.Brand;
                ws.Cells[string.Format("C{0}", rowstart)].Value = item.Model;
                ws.Cells[string.Format("D{0}", rowstart)].Value = item.Description;
                ws.Cells[string.Format("E{0}", rowstart)].Value = item.Edquip;
                ws.Cells[string.Format("F{0}", rowstart)].Value = item.Serial;
                ws.Cells[string.Format("G{0}", rowstart)].Value = item.SpecialisedDevice;
                ws.Cells[string.Format("H{0}", rowstart)].Value = item.BuildingLocation;
                ws.Cells[string.Format("I{0}", rowstart)].Value = item.HasPowerSupply;
                ws.Cells[string.Format("J{0}", rowstart)].Value = item.HasPowerCable;
                ws.Cells[string.Format("K{0}", rowstart)].Value = item.HasCover;
                ws.Cells[string.Format("L{0}", rowstart)].Value = item.Accessories;
                ws.Cells[string.Format("M{0}", rowstart)].Value = item.DeviceNotes;
                ws.Cells[string.Format("N{0}", rowstart)].Value = item.WriteOff;
                ws.Cells[string.Format("O{0}", rowstart)].Value = item.TypeOfDevice;
                rowstart++;

            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename= " + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }

        // GET: Devices/Import
        public ActionResult Import()
        {
            return View();
        }

        [HttpPost]
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
                    List<Devices> listDevices = new List<Devices>();

                    for (int row = 2; row < range.Rows.Count; row++)
                    {
                        Devices p = new Devices();

                        p.Id = ((Excel.Range)range.Cells[row, 1]).Value;
                        p.Brand = ((Excel.Range)range.Cells[row, 2]).Text;
                        p.Model = ((Excel.Range)range.Cells[row, 3]).Text;
                        p.Description = ((Excel.Range)range.Cells[row, 4]).Text;
                        p.Edquip = ((Excel.Range)range.Cells[row, 9]).Text;
                        p.Serial = ((Excel.Range)range.Cells[row, 10]).Text;

                        listDevices.Add(p);
                        _context.Devices.Add(p);
                        _context.SaveChanges();


                    }

                    ViewBag.ListDevices = listDevices;
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
    }
}
