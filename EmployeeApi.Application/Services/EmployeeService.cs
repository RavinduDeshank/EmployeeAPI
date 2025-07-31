using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        public IEnumerable<Employee> GetAllEmployees() => _employeeRepository.GetAllEmployees();

        public Employee? GetEmployeeById(int id) => _employeeRepository.GetEmployeeById(id);

        public bool AddEmployee(Employee emp) => _employeeRepository.AddEmployee(emp);

        public bool UpdateEmployee(Employee emp) => _employeeRepository.UpdateEmployee(emp);

        public bool DeleteEmployee(int id) => _employeeRepository.DeleteEmployee(id);
    }
}
