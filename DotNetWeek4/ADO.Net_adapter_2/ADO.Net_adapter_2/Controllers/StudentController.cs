using ADO.Net_adapter_2.Interfaces;
using ADO.Net_adapter_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ADO.Net_adapter_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("GetAllStudents")]
        public IActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return Ok(students);
        }
        [HttpPut("incrementAllAges")]
        public IActionResult IncrementAllAges()
        {
            _studentService.IncreamentAllAges();
            return Ok("All ages incremented successfully.");
        }
        [HttpGet("FilterStudentsByAge/{age}")]
        public IActionResult FilterStudentByAge(int age)
        {
            var filteredStudents = _studentService.FilterStudentsByAge(age);
            return Ok(filteredStudents);
        }
    }
}

