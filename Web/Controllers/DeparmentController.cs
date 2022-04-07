using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeparmentController : ControllerBase
    {
        private readonly IDeparmentService _departmentService;
        public DeparmentController(IDeparmentService deparmentService)
        {
            _departmentService = deparmentService;

        }
        [HttpGet]
        public IActionResult Get()
        {
            var departments = _departmentService.GetAll();
            return Ok(departments);
        }
    }
}
