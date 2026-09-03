using college.Application.IServices;
using college.Application.Interfaces;
using college.Domain.DTOs.Enrollment;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public Task<int> CreateEnrollmentAsync(CreateEnrollmentRequestDto dto)
            => _enrollmentRepository.CreateAsync(dto);

        public Task<IEnumerable<EnrollmentResponseDto>> GetAllEnrollmentsAsync()
            => _enrollmentRepository.GetAllAsync();

        public Task<EnrollmentResponseDto?> GetEnrollmentByIdAsync(int id)
            => _enrollmentRepository.GetByIdAsync(id);

        public Task<bool> UpdateEnrollmentAsync(UpdateEnrollmentRequestDto dto)
            => _enrollmentRepository.UpdateAsync(dto);

        public Task<bool> DeleteEnrollmentAsync(int id)
            => _enrollmentRepository.DeleteAsync(id);
    }
}
