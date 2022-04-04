using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using Web.Helpers.Auth;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IEmployeeService _employeeService;

        public TokenController(IConfiguration configuration, IEmployeeService employeeService)
        {
            _configuration = configuration;
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult Post(EmployeeDTO employee)
        {
            if (!string.IsNullOrEmpty(employee.EmployeeId) && !string.IsNullOrEmpty(employee.PasswordOriginal))
            {
                EmployeeDTO user = _employeeService.Login(employee);

                if (user != null)
                {
                    string token = JwtManager.GenerateToken(_configuration, user);
                    return Ok(new
                    {
                        employee = new
                        {
                            user.Id,
                            user.EmployeeId,
                            user.FirstName,
                            user.LastName
                        },
                        token
                    });
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}