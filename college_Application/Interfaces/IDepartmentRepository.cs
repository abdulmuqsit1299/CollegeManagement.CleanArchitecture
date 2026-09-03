using college.Domain.DTOs.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<int> CreateAsync(CreateDepartmentRequestDto departmentDto);
        Task<IEnumerable<DepartmentResponseDto>> GetAllAsync();
        Task<DepartmentResponseDto?> GetByIdAsync(int departmentId);
        Task<bool> UpdateAsync(UpdateDepartmentRequestDto departmentDto);
        Task<bool> DeleteAsync(int departmentId);
    }
}
