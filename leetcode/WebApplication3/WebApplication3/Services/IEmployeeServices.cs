using WebApplication3.Model;
using System.Collections.Generic;

namespace WebApplication3.Services
{
    public interface IEmployeeServices
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee newEmployee);
        Employee UpdateEmployee(int id, Employee updatedEmployee);
        bool DeleteEmployee(int id);
    }
}
