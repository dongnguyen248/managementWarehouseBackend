using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineController : ApiController
    {
        private readonly ILineService _lineService;

        public LineController(ILineService lineService)
        {
            _lineService = lineService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var lines = _lineService.GetAll();
            return Ok(lines);
        }
    }
}