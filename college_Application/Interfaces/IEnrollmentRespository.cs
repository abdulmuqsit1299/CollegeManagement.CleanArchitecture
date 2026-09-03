using college.Domain.DTOs.Enrollment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<int> CreateAsync(CreateEnrollmentRequestDto dto);
        Task<IEnumerable<EnrollmentResponseDto>> GetAllAsync();
        Task<EnrollmentResponseDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(UpdateEnrollmentRequestDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
