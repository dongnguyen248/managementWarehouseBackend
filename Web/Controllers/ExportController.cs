﻿using DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportController : ControllerBase
    {
        private readonly IExportService _exportService;
        private readonly IReportMaterial _reportService;
        private IWebHostEnvironment _hostEnvironment;
        
        public ExportController(IExportService exportService, IReportMaterial reportService, IWebHostEnvironment webHostEnvironment)
        {
            _exportService = exportService;
            _reportService = reportService;
            _hostEnvironment = webHostEnvironment;
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
        public FileContentResult GetExcelExportHistories(DateTime fromDate, DateTime toDate)
        {

            string fileName = _reportService.GetReportExcel(fromDate, toDate);



            
            string contentRootPath = _hostEnvironment.ContentRootPath;
            var path = Path.Combine(contentRootPath, $"FileReport\\{fileName}");

            var content = System.IO.File.ReadAllBytes(@path);

            var result = new FileContentResult(content, "application/octet-stream")
            {
                FileDownloadName = fileName,
            };
            return result;
            
        }
        [HttpGet("export-histories-excel")]
        public FileContentResult GetExceltHistories(DateTime fromDate, DateTime toDate)
        {

            string fileName = _reportService.GetExportHistoriesExcel(fromDate, toDate);

            string contentRootPath = _hostEnvironment.ContentRootPath;
            var path = Path.Combine(contentRootPath, $"FileReport\\{fileName}");

            var content = System.IO.File.ReadAllBytes(@path);

            var result = new FileContentResult(content, "application/octet-stream")
            {
                FileDownloadName = fileName,
            };
            return result;
        }
        [HttpGet("export-histories")]
        public IActionResult GetAllHistories()
        {
            return Ok(_exportService.GetAllExpHis());
        }

        [HttpDelete]
        public IActionResult DeleteHistory(int id)
        {
            try
            {
                _exportService.DeleteHistory(id);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }



    }
}
