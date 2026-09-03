using college.Application.IServices;
using college.Application.Interfaces;
using college.Domain.DTOs.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<int> CreateCourseAsync(CreateCourseRequestDto courseDto)
            => _courseRepository.CreateAsync(courseDto);
        
        public Task<IEnumerable<CourseResponseDto>> GetAllCoursesAsync()
            => _courseRepository.GetAllAsync();

        public Task<CourseResponseDto?> GetCourseByIdAsync(int courseId)
            => _courseRepository.GetByIdAsync(courseId);

        public Task<bool> UpdateCourseAsync(UpdateCourseRequestDto courseDto)
            => _courseRepository.UpdateAsync(courseDto);

        public Task<bool> DeleteCourseAsync(int courseId)
            => _courseRepository.DeleteAsync(courseId);

    }
}
