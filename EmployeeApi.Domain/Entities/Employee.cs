using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Domain.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Department is required")]
        [StringLength(50, ErrorMessage = "Department name cannot exceed 50 characters.")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [StringLength(50, ErrorMessage = "Position name cannot exceed 50 characters.")]
        public string Position { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a non-negative value.")]
        public decimal Salary { get; set; }
    }
}
