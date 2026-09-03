using college.Application.IServices;
using college.Domain.DTOs.Department;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace college.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
                return NotFound();
            return Ok(department);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDepartmentRequestDto dto)
        {
            var id = await _departmentService.CreateDepartmentAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateDepartmentRequestDto dto)
        {
            if (id != dto.DepartmentId)
                return BadRequest("DepartmentId mismatch");

            var updated = await _departmentService.UpdateDepartmentAsync(dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _departmentService.DeleteDepartmentAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
