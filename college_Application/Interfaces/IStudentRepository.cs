using college.Domain.DTOs.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<int> CreateAsync(CreateStudentRequestDto studentDto);
        Task<IEnumerable<StudentResponseDto>> GetAllAsync();
        Task<StudentResponseDto?> GetByIdAsync(int studentId);
        Task<bool> UpdateAsync(UpdateStudentRequestDto studentDto);
        Task<bool> DeleteAsync(int studentId);
    }
}
