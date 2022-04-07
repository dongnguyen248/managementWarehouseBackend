using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

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
    }
}
