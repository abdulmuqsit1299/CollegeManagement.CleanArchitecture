using college.Application.IServices;
using college.Domain.DTOs.Enrollment;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace college.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _enrollmentService.GetAllEnrollmentsAsync();
            return Ok(enrollments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
                return NotFound();
            return Ok(enrollment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEnrollmentRequestDto dto)
        {
            var id = await _enrollmentService.CreateEnrollmentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEnrollmentRequestDto dto)
        {
            if (id != dto.EnrollmentId)
                return BadRequest("EnrollmentId mismatch");

            var updated = await _enrollmentService.UpdateEnrollmentAsync(dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _enrollmentService.DeleteEnrollmentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
