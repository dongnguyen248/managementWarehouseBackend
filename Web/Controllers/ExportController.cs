using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IExportService _exportService;
        public ExportController(IExportService exportService)
        {
            _exportService = exportService;
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
            IEnumerable<ExportHistoryDTO> exportHistories = _exportService.GetReportExcel(fromDate, toDate);
            IEnumerable<ReportExcelVM> exportHistoriesVM = new ReportExcelVM().Gets(exportHistories);

            return Ok(exportHistoriesVM);

        }

       

    }
}
