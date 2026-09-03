using college.Application.IServices;
using college.Application.Interfaces;
using college.Domain.DTOs.Student;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> CreateStudentAsync(CreateStudentRequestDto studentDto)
        {
            return await _studentRepository.CreateAsync(studentDto);
        }

        public Task<bool> CreateStudentAsync(UpdateStudentRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentResponseDto>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<StudentResponseDto?> GetStudentByIdAsync(int studentId)
        {
            return await _studentRepository.GetByIdAsync(studentId);
        }

        public Task<bool> UpdateStudentAsync(UpdateStudentRequestDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
