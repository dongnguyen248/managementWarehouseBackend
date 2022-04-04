using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using Web.Helpers.Core;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportHistoryController : ControllerBase
    {
        private readonly IImportService _importService;
        public ImportHistoryController(IImportService importService)
        {
            _importService = importService;

        }
        [HttpGet("{page}/{pageSize}")]
        public IActionResult GetAllImportHistories(int page, int pageSize)
        {
            IEnumerable<ImportHistoryDTO> importHistories = _importService.GetAll(page, pageSize, out int totalRow);
            IEnumerable<ImportHistoryVM> importHistoriesVMs = new ImportHistoryVM().Gets(importHistories);
            PaginationSet<ImportHistoryVM> pagedSet = new PaginationSet<ImportHistoryVM>()
            {
                PageIndex = page,
                TotalRows = totalRow,
                PageSize = pageSize,
                Items = importHistoriesVMs
            };
            return Ok(pagedSet);
        }
        [HttpGet("{page}/{pageSize}/search")]
        public IActionResult Search(DateTime dateFrom, DateTime dateTo, string qCode, string Po, string Line, string Supplier, int page, int pageSize)
        {
            //DateTime dateFrom, DateTime dateTo, string Qcode, string PO, string Line, string Supplier, int page, int pageSize, out int totalRow
            IEnumerable<ImportHistoryDTO> importHistories = _importService.Search(dateFrom, dateTo, qCode, Po, Line, Supplier, page, pageSize, out int totalRow);
            IEnumerable<ImportHistoryVM> importHistoryVMs = new ImportHistoryVM().Gets(importHistories);
            PaginationSet<ImportHistoryVM> pagedSet = new PaginationSet<ImportHistoryVM>()
            {
                PageIndex = page,
                TotalRows = totalRow,
                PageSize = pageSize,
                Items = importHistoryVMs
            };
            return Ok(pagedSet);
        }
    }
}
