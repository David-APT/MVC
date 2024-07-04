using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bizom.Models;
using Syncfusion.XlsIO;
using System.Data;
using System.IO;

namespace Bizom.Controllers
{
    public class EXCELController : Controller
    {
        DbBIZ OBJ = new DbBIZ();
        public ActionResult DownloadExcel()
        {
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                //Initialize Application
                IApplication r = excelEngine.Excel;

                //Set the default application version as Excel 2016
                r.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook with a worksheet
                IWorkbook workbook = r.Workbooks.Create(1);

                //Access first worksheet from the workbook instance
                IWorksheet worksheet = workbook.Worksheets[0];

                //Export data to Excel
                DataTable dataTable = gettable();
                worksheet.ImportDataTable(dataTable, true, 1, 1);
                worksheet.UsedRange.AutofitColumns();

                //Save the workbook to disk in xlsx format
                workbook.SaveAs("PRODUCT.xlsx", ExcelSaveType.SaveAsXLS, HttpContext.ApplicationInstance.Response, ExcelDownloadType.Open);
            }
            return View();

        }
        private DataTable gettable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("BRAND", typeof(string));
            table.Columns.Add("SKU DESCRIPTION", typeof(string));
            table.Columns.Add("MRP", typeof(string));
            table.Columns.Add("MARGIN", typeof(string));
            table.Columns.Add("CASE QTY", typeof(string));
            table.Columns.Add("PRICE", typeof(string));
            foreach (var item in OBJ.products.ToList())
            {
                table.Rows.Add( item.PRODUCT_BRAND, item.PRODUCT_NAME, item.PRODUCT_MAR, item.PRODUCT_MARGIN, item.PRODUCT_CASE, item.PRODUCT_PRICE);
            }
            return table;
        }
        [HttpPost]
        public ActionResult ImportData(HttpPostedFileBase king)
        {
            string path = Path.GetFileName(king.FileName);
            string name = Path.Combine(Server.MapPath("~/EXCEL"), path);
            king.SaveAs(name);
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                // Create an instance of IApplication
                IApplication application = excelEngine.Excel;

                // Open an existing Excel file
                IWorkbook workbook = application.Workbooks.Open(name);

                // Access worksheets, perform operations, etc.
                // Example:
                IWorksheet worksheet = workbook.Worksheets[0];
                var usedRange = worksheet.UsedRange;

                for (int row = 4; row <= usedRange.Rows.Length; row++)
                {

                    IRange BRAND = worksheet.Range[row, 1];
                    IRange  SKU_DESCRIPTION = worksheet.Range[row, 2];
                    IRange MRP = worksheet.Range[row, 3];
                    IRange MARGIN = worksheet.Range[row, 4];
                    IRange CASE_QTY = worksheet.Range[row, 5];
                    IRange PRICE = worksheet.Range[row,6];
                    var data = new product
                    {
                        PRODUCT_BRAND = BRAND.Text ,
                        PRODUCT_NAME = SKU_DESCRIPTION.Text,
                        PRODUCT_MAR = Convert.ToDouble(MRP.Number),
                        PRODUCT_MARGIN = Convert.ToDouble(MARGIN.Number),
                        PRODUCT_CASE = Convert.ToDouble(CASE_QTY.Number),
                        PRODUCT_PRICE = Convert.ToDouble(PRICE.Number),

                    };

                    OBJ.products.Add(data);
                    OBJ.SaveChanges();
                }
                return RedirectToAction("PRODUCTREAD", "PRODUCTREAD");
            }
        }
    }
}