using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CostAccountController : ControllerBase
    {
        private readonly ICostAccountService _costAccountService;
        public CostAccountController(ICostAccountService costAccountService)
        {
            _costAccountService = costAccountService;

        }
        [HttpGet]
        public IActionResult GetCostAccount()
        {
            var coustAccounts = _costAccountService.GetAll();
            return Ok(coustAccounts);
        }
    }
}
