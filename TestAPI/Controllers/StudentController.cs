using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service.Interfaces;
using DATA.Entities;
using Models.DTOs;

namespace UniversityApplication.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<StudentDTO> GetStudents()
        {
            var student = _studentService.GetStudents();

            return student;
        }

        [HttpGet]
        [Route("GetStudentById")]
        public IActionResult GetStudentById(int id)
        {
            StudentDTO student = _studentService.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student with that id does not exist!");
            }

            return Ok(student);
        }

        [HttpDelete("RemoveStudent/{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (ModelState.IsValid)
            {
                return Ok(_studentService.DeleteStudent(id));
            }
            return BadRequest();
        }

        [HttpPost("AddStudent")]
        public IActionResult Post([FromBody] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                var newStudent = _studentService.AddStudent(student);
                return Created($"Student with id {newStudent.Id} is created", newStudent.Id);
            }

            return UnprocessableEntity(ModelState);
        }

        [HttpPut("UpdateStudent/{id:int}")]
        public IActionResult Put([FromRoute] int id, [FromBody] StudentDTO student)
        {
            if (ModelState.IsValid)
            {
                student.Id = id;
                var result = _studentService.UpdateStudent(student);

                return result != null
                    ? Ok(result)
                    : NoContent();
            }
            return BadRequest();
        }
    }
}
