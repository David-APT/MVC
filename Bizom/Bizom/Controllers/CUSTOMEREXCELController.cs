using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using Syncfusion.XlsIO;
using System.Data.Entity;
using System.Data;
using System.IO;

namespace Bizom.Controllers
{
    public class CUSTOMEREXCELController : Controller
    {
        DbBIZ obj = new DbBIZ();
        public ActionResult DOWNLOADEXCEL()
        {
            using (ExcelEngine excelengine = new ExcelEngine())
            {
                IApplication customer = excelengine.Excel;

                customer.DefaultVersion = ExcelVersion.Xlsx;

                IWorkbook workbook = customer.Workbooks.Create(1);

                IWorksheet worksheet = workbook.Worksheets[0];

                DataTable datatable = GETTABLE();
                worksheet.ImportDataTable(datatable, true, 1, 1);
                worksheet.UsedRange.AutofitColumns();

                workbook.SaveAs("CUSTOMER.xlsx", ExcelSaveType.SaveAsXLS, HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
            }
            return View();
        }
        private DataTable GETTABLE()
        {
            DataTable table = new DataTable();
            table.Columns.Add("SELECT BEAT", typeof(string));
            table.Columns.Add("OUTLET TYPE", typeof(string));
            table.Columns.Add("OUTLET NAME", typeof(string));
            table.Columns.Add("OUTLET ADDRESS", typeof(string));
            table.Columns.Add("OWNER NAME", typeof(string));
            foreach (var item in obj.Retailers.ToList())
            {
                table.Rows.Add(@item.Select_Beat, @item.Outlet_Types, @item.Outlet_Name, @item.Outlet_Address, @item.Owner_Name);
            }
            return table;
        }
        [HttpPost]
        public ActionResult IMPORTEXCEL(HttpPostedFileBase customer)
        {
            string path = Path.GetFileName(customer.FileName);
            string rome = Path.Combine(Server.MapPath("~/EXCEL"), path);
            customer.SaveAs(rome);

            using(ExcelEngine excelengine = new ExcelEngine ())
            {
                IApplication application = excelengine.Excel;
                
                IWorkbook workbook = application.Workbooks.Open(rome);

                IWorksheet worksheet = workbook.Worksheets[0];
                var usedrange = worksheet.UsedRange;

                for (int row = 2; row <= usedrange.Rows.Length; row++)
                {
                    IRange BEAT = worksheet.Range[row, 1];
                    IRange OUTLET_TYPE = worksheet.Range[row, 2];
                    IRange OUTLET_NAME = worksheet.Range[row, 3];
                    IRange OUTLET_ADDRESS = worksheet.Range[row, 4];
                    IRange OWNER_NAME = worksheet.Range[row, 5];
                    var DATA = new Retailer
                    {
                        Select_Beat = BEAT.Text,
                        Outlet_Types = OUTLET_TYPE.Text,
                        Outlet_Name = OUTLET_NAME.Text,
                        Outlet_Address = OUTLET_ADDRESS.Text,
                        Owner_Name = OWNER_NAME.Text,
                    };
                    obj.Retailers.Add(DATA);
                    obj.SaveChanges();
                }
                return RedirectToAction("Read", "Read");
            }
        }
    }
}
