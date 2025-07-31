using EmployeeApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee? GetEmployeeById(int id);
        
        bool AddEmployee(Employee employee);
        
        bool UpdateEmployee(Employee employee);
        
        bool DeleteEmployee(int id);
    }
}
