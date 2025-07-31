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
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo) => _repo = repo;

        public IEnumerable<Employee> GetAllEmployees() => _repo.GetAllEmployees();

        public Employee? GetEmployeeById(int id) => _repo.GetEmployeeById(id);

        public bool AddEmployee(Employee emp) => _repo.AddEmployee(emp);

        public bool UpdateEmployee(Employee emp) => _repo.UpdateEmployee(emp);

        public bool DeleteEmployee(int id) => _repo.DeleteEmployee(id);
    }
}
