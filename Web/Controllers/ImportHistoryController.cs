using Data;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Web.Helpers.Core;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportHistoryController : ControllerBase
    {
        private readonly IImportService _importService;

        public ImportHistoryController(IImportService importService )
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
                Items = importHistoriesVMs,
                Total = importHistories.Sum(x => x.Quantity)

            };
            return Ok(pagedSet);
        }
        [HttpGet("{page}/{pageSize}/search")]
        public IActionResult Search(DateTime dateFrom, DateTime dateTo, string qCode, string Po, string Line, string Supplier, int page, int pageSize)
        {
            
            IEnumerable<ImportHistoryDTO> importHistories = _importService.Search(dateFrom, dateTo, qCode, Po, Line, Supplier, page, pageSize, out int totalRow);
            IEnumerable<ImportHistoryVM> importHistoryVMs = new ImportHistoryVM().Gets(importHistories);
            PaginationSet<ImportHistoryVM> pagedSet = new PaginationSet<ImportHistoryVM>()
            {
                PageIndex = page,
                TotalRows = totalRow,
                PageSize = pageSize,
                Items = importHistoryVMs,

            };
            return Ok(pagedSet);
        }
        [Authorize]
        [HttpPost("add-importHistory")]
        public IActionResult AddImportHistory(ImportHistoryDTO importHistory)
        {
            try
            {
                int handler = int.Parse(User.Claims.FirstOrDefault(x => x.Type.Equals("UserId", StringComparison.Ordinal)).Value);
                importHistory.Handler.Equals(handler);
                _importService.Add(importHistory);
                
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("update-history-material")]
        public IActionResult UpdateMaterial(ImportHistoryDTO importHistory)
        {
            try
            {
                _importService.UpdateImportHistory(importHistory);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
        [HttpDelete]
        public IActionResult DeleteImportHistory(int id)
        {
            try
            {
                _importService.Delete(id);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
        }
    }
}
