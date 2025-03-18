using WebApplication3.Model;
using System.Collections.Generic;
using System.Linq;




namespace WebApplication3.Services
{
    public class EmployeeServices : IEmployeeServices
    {

        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Anwar", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Rahul", Department = "HR", Salary = 40000 }
        };

        public List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee AddEmployee(Employee newEmployee)
        {
            newEmployee.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1; // Auto-generate ID
            employees.Add(newEmployee);
            return newEmployee;
        }

        public Employee UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return null;

            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null) return false;

            employees.Remove(employee);
            return true;
        }

    }
}
