using EmployeeApi.Application.DTOs;
using EmployeeApi.Application.Services;
using EmployeeApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _service;
        public EmployeesController(EmployeeService service) => _service = service;

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employeeList = _service.GetAllEmployees();
            if(employeeList == null || !employeeList.Any())
            {
                return NotFound("Employees were not found.");
            }
            return Ok(employeeList);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = _service.GetEmployeeById(id);
            if (employee != null) { 
                return Ok(employee);
            }
            return NotFound("Employee not found.");
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] CreateEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                Position = employeeDto.Position,
                Salary = employeeDto.Salary
            };

            _service.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);

        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] CreateEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employee = new Employee
            {
                Id = id,
                Name = employeeDto.Name,
                Department = employeeDto.Department,
                Position = employeeDto.Position,
                Salary = employeeDto.Salary
            };

            _service.UpdateEmployee(employee);
            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            if (_service.GetEmployeeById(id) is null) return NotFound();
            _service.DeleteEmployee(id);
            return Ok("Delete Successfully");
        }
    }
}
