using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Services.Interfaces;
using System;
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
        [HttpGet]
        public IActionResult GetAllEmp()
        {
            var employees = _employeeService.GetAllEmployee();
            return Ok(employees);
        }
        [HttpPost("change-password")]
        public IActionResult ChangePassword(int id,string newPassword,string oldPassword)
        {
            try
            {
                _employeeService.ChangePassword(id, newPassword,oldPassword);
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        [HttpPost("add-user")]
        public IActionResult CreateEmployee(EmployeeDTO employee)
        {
            try
            {

                _employeeService.Create(employee);
                return Ok();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("update-user")]
        public IActionResult UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                _employeeService.Update(employee);
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-user")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employeeService.Delete(id);
                return Ok();

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
                            user.LastName,
                            user.IsAdmin
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