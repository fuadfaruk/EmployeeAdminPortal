using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Dtos;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    // localhost:[port]/api/employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var allEmployees = _context.Employees.ToList();

            return Ok(allEmployees);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var employeeEntity = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            _context.Employees.Add(employeeEntity);
            _context.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.Name = updateEmployeeDto.Name;
            existingEmployee.Email = updateEmployeeDto.Email;
            existingEmployee.Phone = updateEmployeeDto.Phone;
            existingEmployee.Salary = updateEmployeeDto.Salary;
            _context.SaveChanges();

            return Ok(existingEmployee);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var existingEmployee = _context.Employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(existingEmployee);
            _context.SaveChanges();

            return Ok();
        }
    }
}
