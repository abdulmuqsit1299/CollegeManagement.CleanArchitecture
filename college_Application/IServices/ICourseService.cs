using college.Domain.DTOs.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.IServices
{
    public interface ICourseService
    {
        Task<int> CreateCourseAsync(CreateCourseRequestDto courseDto);
        Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync();
        Task<CourseResponseDto?> GetCourseByIdAsync(int courseId);
        Task<bool> UpdateCourseAsync(UpdateCourseRequestDto courseDto);
        Task<bool> DeleteCourseAsync(int courseId);
    }
}
