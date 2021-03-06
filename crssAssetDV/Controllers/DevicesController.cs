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
//using OfficeOpenXml.Style;
using System.Drawing;
using crssAssetDV.ViewModels;
//using CSVLibraryAK;


namespace crssAssetDV.Controllers
{
    public class DevicesController : Controller
    {

        private readonly ApplicationDbContext _context;
        //private readonly Devices devices;

        public DevicesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: DevicesController
        public ActionResult Index()
        {

            Process[] excelProcs = Process.GetProcessesByName("EXCEL");
            foreach (Process proc in excelProcs)
            {
                proc.Kill();
            }

            return View();

        }

        // GET: DevicesController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var devices = _context.Devices
                    .Include(t => t.TypeOfDevice)
                    .Include(r => r.RoleDevice)
                    .Include(d => d.DamagedSelectOption)
                    .Include(d => d.DeviceNote)
                    .SingleOrDefault(p => p.Id == id);



            if (devices == null)
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // GET: Devices/New
        public ActionResult New()
        {
            var devices = _context.Devices;
            //var devices = _context.Devices
            //    .Include(t => t.TypeOfDevice)
            //    .Include(r => r.RoleDevice)
            //    .Include(d => d.DamagedSelectOption);
                
            var typeOfDevices = _context.TypeOfDevices.ToList();
            var roleDevices = _context.RoleDevices.ToList();
            var damagedSelectOptions = _context.DamagedSelectOptions.ToList();
            var deviceNotes = _context.DeviceNotes.ToList();

            var viewModel = new DeviceFormViewModel
            {

                TypeOfDevices = typeOfDevices,
                RoleDevices = roleDevices,
                DamagedSelectOptions = damagedSelectOptions,
                DeviceNotes = deviceNotes,
                //devices = Devices,

            };

            return View("DeviceForm", viewModel);

        }

        [HttpPost]
        public ActionResult Create(Device devices)
        {
            if (devices.Id == 0)
                _context.Devices.Add(devices);
            else
            {
                var deviceInDb = _context.Devices.Single(d => d.Id == devices.Id);
                

                deviceInDb.TypeOfDeviceId = devices.TypeOfDeviceId;
                deviceInDb.Brand = devices.Brand;
                deviceInDb.Model = devices.Model;
                deviceInDb.Edquip = devices.Edquip;
                deviceInDb.Serial = devices.Serial;
                deviceInDb.RoleDeviceId = devices.RoleDeviceId;
                deviceInDb.BuildingLocation = devices.BuildingLocation;
                deviceInDb.Accessories = devices.Accessories;
                deviceInDb.DamagedRefId = devices.DamagedRefId;
                deviceInDb.WriteOff = devices.WriteOff;
                deviceInDb.WriteOffDate = devices.WriteOffDate;
                deviceInDb.WarrantyTo = devices.WarrantyTo;
                deviceInDb.PurchaseDate = devices.PurchaseDate;
                deviceInDb.AssetChecked = devices.AssetChecked;
                deviceInDb.AppleModelRef = devices.AppleModelRef;
                deviceInDb.Capacity = devices.Capacity;
                deviceInDb.DeviceNoteId = devices.DeviceNoteId;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Devices");
        }


        // GET: Devices/Edit/5
        public ActionResult Edit(int id)
        {
            var devices = _context.Devices
                    .Include(t => t.TypeOfDevice)
                    .Include(r => r.RoleDevice)
                    .Include(d => d.DamagedSelectOption)
                    .Include(d => d.DeviceNote)
                    .SingleOrDefault(t => t.Id == id);

            if (devices == null)
                return HttpNotFound();

            var viewModel = new DeviceFormViewModel
            {
                Devices = devices,
                TypeOfDevices = _context.TypeOfDevices.ToList(),
                RoleDevices = _context.RoleDevices.ToList(),
                DamagedSelectOptions = _context.DamagedSelectOptions.ToList(),
                DeviceNotes = _context.DeviceNotes.ToList()

            };
            return View("DeviceForm", viewModel);

        }

        // GET: Devices/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Devices devices = _context.Devices.Find(id);

            var devices = _context.Devices
                .Include(t => t.TypeOfDevice)
                .Include(r => r.RoleDevice)
                .Include(d => d.DamagedSelectOption)
                .Include(d => d.DeviceNote)
                .SingleOrDefault(t => t.Id == id);

            if (devices == null)
            {
                return HttpNotFound();
            }
            return View(devices);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Device devices = _context.Devices.Find(id);
            _context.Devices.Remove(devices);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        //GET: Devices/Import
        public ActionResult Import()
        {
            return View();
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
                    List<importModel> importDevices = new List<importModel>();
                    List<Device> listDevices = new List<Device>();

                    for (int row = 2; row < range.Rows.Count; row++)
                    {
                        Device p = new Device();
                        p.Brand = ((Excel.Range)range.Cells[row, 1]).Text;
                        p.Model = ((Excel.Range)range.Cells[row, 2]).Text;
                        p.DamagedRefId = Convert.ToInt32(((Excel.Range)range.Cells[row, 3]).Value);
                        p.TypeOfDeviceId = Convert.ToInt32(((Excel.Range)range.Cells[row, 4]).Value);
                        p.RoleDeviceId = Convert.ToInt32(((Excel.Range)range.Cells[row, 5]).Value);
                        p.Edquip = ((Excel.Range)range.Cells[row, 6]).Text;
                        p.Serial = ((Excel.Range)range.Cells[row, 7]).Text;
                        p.Accessories = ((Excel.Range)range.Cells[row, 8]).Text;
                        //p.WriteOff = Convert.ToBoolean(Convert.ToInt32(((Excel.Range)range.Cells[row, 11]).Value));

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