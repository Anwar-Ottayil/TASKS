using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Department { get; set; }
            public double Salary { get; set; }
        }
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Anwar", Department = "IT", Salary = 50000 },
            new Employee { Id = 2, Name = "Rahul", Department = "HR", Salary = 40000 }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            return Ok(employee);
        }
        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee newEmployee)
        {
            newEmployee.Id = employees.Count > 0 ? employees.Max(e => e.Id) + 1 : 1; 
            employees.Add(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmployee.Id }, newEmployee);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee updatedEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            employee.Name = updatedEmployee.Name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;
            return Ok(employee);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound(new { message = "Employee not found" });

            employees.Remove(employee);
            return Ok(new { message = "Employee deleted successfully" });
        }

    }
}
