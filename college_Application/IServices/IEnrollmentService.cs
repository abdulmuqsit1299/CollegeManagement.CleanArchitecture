using college.Domain.DTOs.Enrollment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.IServices
{
    public interface IEnrollmentService
    {
        Task<int> CreateEnrollmentAsync(CreateEnrollmentRequestDto dto);
        Task<IEnumerable<EnrollmentResponseDto>> GetAllEnrollmentsAsync();
        Task<EnrollmentResponseDto?> GetEnrollmentByIdAsync(int id);
        Task<bool> UpdateEnrollmentAsync(UpdateEnrollmentRequestDto dto);
        Task<bool> DeleteEnrollmentAsync(int id);
    }
}
