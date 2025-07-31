using EmployeeApi.Domain.Entities;
using EmployeeApi.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Infrastructure.Repositories
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();
        private int _nextId = 1;


        public IEnumerable<Employee> GetAllEmployees() => _employees;
        
        public Employee? GetEmployeeById(int id) => _employees.FirstOrDefault(e => e.Id == id);
        
        public bool AddEmployee(Employee employeeData) 
        {
            employeeData.Id = _nextId++;
            _employees.Add(employeeData);
            return true;
        }
        
        public bool UpdateEmployee(Employee employeeData)
        {
            var employee = GetEmployeeById(employeeData.Id);

            employee.Name = employeeData.Name;
            employee.Department = employeeData.Department;
            employee.Position = employeeData.Position;
            employee.Salary = employeeData.Salary;
            return true;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            _employees.Remove(employee);
            return true;
        }
    }
}
