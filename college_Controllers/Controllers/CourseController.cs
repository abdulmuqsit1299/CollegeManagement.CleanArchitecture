using college.Application.IServices;
using college.Domain.DTOs.Course;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace college.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // 🔹 GET: api/Course
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        // 🔹 GET: api/Course/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
                return NotFound(new { Message = $"Course with ID {id} not found" });
            return Ok(course);
        }

        // 🔹 POST: api/Course
        [HttpPost]
        public async Task<IActionResult> Create(CreateCourseRequestDto dto)
        {
            var createdCourseId = await _courseService.CreateCourseAsync(dto);
            return Ok(createdCourseId);
        }

        // 🔹 PUT: api/Course/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCourseRequestDto dto)
        {
            if (id != dto.CourseId)
                return BadRequest(new { Message = "Course ID mismatch." });
            var updated = await _courseService.UpdateCourseAsync(dto);
            if (!updated)
                return NotFound(new { Message = $"Course with ID {id} not found" });
            return NoContent();
        }

        // 🔹 DELETE: api/Course/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _courseService.DeleteCourseAsync(id);
            if (!deleted)
                return NotFound(new { Message = $"Course with ID {id} not found" });
            return NoContent();
        }
    }
}
