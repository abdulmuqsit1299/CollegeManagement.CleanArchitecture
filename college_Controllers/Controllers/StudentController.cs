using Microsoft.AspNetCore.Mvc;
using college.Application.IServices;
using college.Domain.DTOs.Student;
namespace college.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // 🔹 GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return Ok(students);
        }

        // 🔹 GET: api/Student/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound(new { Message = $"Student with ID {id} not found" });

            return Ok(student);
        }

        // 🔹 POST: api/student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentRequestDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Call service to create student → ye int return karega (new studentId)
            var createdStudentId = await _studentService.CreateStudentAsync(studentDto);

            // Return 201 Created with location header
            return CreatedAtAction(nameof(GetStudentById), new { id = createdStudentId }, studentDto);
        }

        // 🔹 PUT: api/student/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] UpdateStudentRequestDto studentDto)
        {
            if (id != studentDto.StudentId)
                return BadRequest(new { Message= "Student ID mismatch." });

            var updated = await _studentService.UpdateStudentAsync(studentDto);
            if (!updated)
                return NotFound(new { Message = $"Student with ID {id} not found" });

            return NoContent();
        }

        // 🔹 Delete Student (DELETE)
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudentAsync(id);
            if (result)
                return Ok("Student deleted successfully.");
            return NotFound("Student not found.");

        }
    }
}
