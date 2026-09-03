using college.Domain.DTOs.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.IServices
{
    public interface IDepartmentService
    {
        Task<int> CreateDepartmentAsync(CreateDepartmentRequestDto dto);
        Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync();
        Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id);
        Task<bool> UpdateDepartmentAsync(UpdateDepartmentRequestDto dto);
        Task<bool> DeleteDepartmentAsync(int id);
    }
}
