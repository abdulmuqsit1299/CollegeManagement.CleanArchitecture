using college.Domain.DTOs.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<int> CreateAsync(CreateCourseRequestDto courseDto);
        Task<IEnumerable<CourseResponseDto>> GetAllAsync();
        Task<CourseResponseDto?> GetByIdAsync(int courseId);
        Task<bool> UpdateAsync(UpdateCourseRequestDto courseDto);
        Task<bool> DeleteAsync(int courseId);
    }
}
