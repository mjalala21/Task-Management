using StudentApi.Models;
using StudentApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace StudentApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentService.GetStudentsAsync();
            return Ok(students);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentService.GetStudentAsync(id);   

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            await _studentService.AddStudentAsync(student);

            return CreatedAtAction(
                nameof(GetStudent),
                new { id = student.Id }, 
                student
                );
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            var StudentToUpdate = await _studentService.UpdateStudentAsync(id, student);

            if (StudentToUpdate == null)
            {
                return NotFound();
            }

            return Ok(StudentToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var Delete = await _studentService.DeleteStudentAsync(id);

            if (!Delete)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
