using college.Domain.DTOs.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.IServices

{
    public interface IStudentService
    {
        Task<bool> CreateStudentAsync(UpdateStudentRequestDto request);
        Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync();
        Task<StudentResponseDto?> GetStudentByIdAsync(int id);
        Task<bool> UpdateStudentAsync(UpdateStudentRequestDto studentDto);
        Task<bool> DeleteStudentAsync(int id);
        Task<int> CreateStudentAsync(CreateStudentRequestDto studentDto);
    }
}
