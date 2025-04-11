using CRUD_ENTITY_FRAMEWORK.Data;
using CRUD_ENTITY_FRAMEWORK.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_ENTITY_FRAMEWORK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
            //return Ok(employee);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee updatedData)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return NotFound();

            employee.Name = updatedData.Name;
            employee.Salary = updatedData.Salary;

            await _context.SaveChangesAsync();
            return NoContent();

        }
    }

}
    
