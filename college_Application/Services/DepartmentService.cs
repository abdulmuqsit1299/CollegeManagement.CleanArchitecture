using college.Application.IServices;
using college.Application.Interfaces;
using college.Domain.DTOs.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public Task<int> CreateDepartmentAsync(CreateDepartmentRequestDto dto)
            => _departmentRepository.CreateAsync(dto);

        public Task<IEnumerable<DepartmentResponseDto>> GetAllDepartmentsAsync()
            => _departmentRepository.GetAllAsync();

        public Task<DepartmentResponseDto?> GetDepartmentByIdAsync(int id)
            => _departmentRepository.GetByIdAsync(id);

        public Task<bool> UpdateDepartmentAsync(UpdateDepartmentRequestDto dto)
            => _departmentRepository.UpdateAsync(dto);

        public Task<bool> DeleteDepartmentAsync(int id)
            => _departmentRepository.DeleteAsync(id);
    }
}
