using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IExportService _exportService;
        private readonly IReportMaterial _reportService;
        public ExportController(IExportService exportService, IReportMaterial reportService)
        {
            _exportService = exportService;
            _reportService = reportService;
        }
        [HttpPost("add-export")]
        public IActionResult AddExportHistory(ExportHistoryDTO exportHistory)
        {
            _exportService.Add(exportHistory);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetExportHistories(int page, int pageSize)
        {
            IEnumerable<ExportHistoryDTO> exportHistories = _exportService.GetAll(page, pageSize, out int totalRow);
            IEnumerable<ExportHistoryVM> exportHistoriesVM = new ExportHistoryVM().Gets(exportHistories);
            
            return Ok(exportHistoriesVM);

        }

        [HttpGet("export-excel")]
        public IActionResult GetExcelExportHistories(DateTime fromDate, DateTime toDate)
        {

            Stream stream = _reportService.GetReportExcel(fromDate, toDate);
            //var buffer = stream as MemoryStream;
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            //HttpContext.Response.Headers.Add("Content-Disposition", "attachment; filename=ExcelDemo.xlsx");
            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            //var _stream = new MemoryStream();
            //using (var xlPackage = new ExcelPackage(_stream))
            //{
            //    var worksheet = xlPackage.Workbook.Worksheets.Add("Users");
            //    var namedStyle = xlPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
            //    worksheet.Cells["A1"].Value = "Sample";
            //    xlPackage.Workbook.Properties.Title = "User List";
            //    xlPackage.Workbook.Properties.Author = "Mohamad Lawand";
            //    xlPackage.Workbook.Properties.Subject = "User List";
            //    xlPackage.Save();
            //    namedStyle.Style.Font.UnderLine = true;
            //}

            stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "users.xlsx");
            // Đây là content Type dành cho file excel, còn rất nhiều content-type khác nhưng cái này mình thấy okay nhất


        }

       

    }
}
