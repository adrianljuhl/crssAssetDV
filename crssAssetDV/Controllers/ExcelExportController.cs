using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using crssAssetDV.Models;


namespace crssAssetDV.Controllers
{
    public class ExcelExportController : Controller
    {
        private IList<Devices> device = new List<Devices>();

        public ExcelExportController()
        {
            for (int i=0; i < 20; i++)
            {
                device.Add(new Devices()
                {
                    Id = i + 1,
                    Brand = "Brand" + (i + 1).ToString(),
                    Model = "Model" + (i + 1).ToString(),
                    Description = "Description" + (i + 1).ToString(),
                    Edquip = "Edquip" + (i + 1).ToString(),
                    Serial = "Serial" + (i + 1).ToString(),
                });
            }
        }
    }

    //public ActionResult Index(string txtFilter)
    //{
    //    txtFilter = txtFilter ?? "";
    //    var result = device.Where(x => x.Edquip.Contains(txtFilter) || x.Serial.Contains(txtFilter) || x.Id.ToString() == txtFilter);
    //    return View(result.ToList());
    //}

    //public void ExportToExcel(string txtFilter)
    //{
    //    txtFilter = txtFilter ?? "";
    //    var result = employees.Where(x => x.Name.Contains(txtFilter) || x.Family.Contains(txtFilter) || x.Id.ToString() == txtFilter).ToList();

    //    DataTable table = new DataTable();
    //    using (var reader = ObjectReader.Create(result))
    //    {
    //        table.Load(reader);
    //    }

    //    using (XLWorkbook wb = new XLWorkbook())
    //    {
    //        wb.Worksheets.Add(table, "Employees");
    //        string myName = HttpContext.Server.UrlEncode("Employees.xlsx");
    //        MemoryStream stream = GetStream(wb);
    //        HttpContext.Response.Clear();
    //        HttpContext.Response.Buffer = true;
    //        HttpContext.Response.AddHeader("content-disposition", "attachment; filename=" + myName);
    //        HttpContext.Response.ContentType = "application/vnd.ms-excel";
    //        HttpContext.Response.BinaryWrite(stream.ToArray());
    //        HttpContext.Response.End();
    //    }
    //}

    //private MemoryStream GetStream(XLWorkbook excelWorkbook)
    //{
    //    MemoryStream fs = new MemoryStream();
    //    excelWorkbook.SaveAs(fs);
    //    fs.Position = 0;
    //    return fs;
    //}



}