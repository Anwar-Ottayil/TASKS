﻿using ADO_CRUD_OPERATION.Models;
using ADO_CRUD_OPERATION;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADO_CRUD_OPERATION.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly StudentService _studentService;

        public CrudController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/student
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            return Ok(_studentService.GetAllStudents());
        }

        // POST: api/student
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            _studentService.AddStudent(student);
            return Ok(new { message = "Student added successfully" });
        }

        // PUT: api/student/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            student.StudentID = id;
            _studentService.UpdateStudent(student);
            return Ok(new { message = "Student updated successfully" });
        }

        // DELETE: api/student/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            _studentService.DeleteStudent(id);
            return Ok(new { message = "Student deleted successfully" });
        }
    }
}





