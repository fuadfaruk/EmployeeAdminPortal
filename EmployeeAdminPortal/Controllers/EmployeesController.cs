using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:[port]/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(new { message = "Get all employees" });
        }
    }
}
