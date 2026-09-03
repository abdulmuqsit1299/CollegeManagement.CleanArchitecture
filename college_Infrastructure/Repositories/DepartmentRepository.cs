using college.Application.Interfaces;
using college.Domain.DTOs.Department;
using Dapper;
using college.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace college.Infrastructure.Repositories
{
     public class DepartmentRepository : IDepartmentRepository
     {
            private readonly DapperContext _context;

            public DepartmentRepository(DapperContext context)
            {
                _context = context;
            }

            public async Task<int> CreateAsync(CreateDepartmentRequestDto dto)
            {
                var sql = "INSERT INTO Departments (DepartmentName) VALUES (@DepartmentName); SELECT CAST(SCOPE_IDENTITY() as int);";
                using var connection = _context.CreateConnection();
                return await connection.ExecuteScalarAsync<int>(sql, dto);
            }

            public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
            {
                var sql = "SELECT DepartmentId, DepartmentName FROM Departments;";
                using var connection = _context.CreateConnection();
                return await connection.QueryAsync<DepartmentResponseDto>(sql);
            }

            public async Task<DepartmentResponseDto?> GetByIdAsync(int id)
            {
                var sql = "SELECT DepartmentId, DepartmentName FROM Departments WHERE DepartmentId = @Id;";
                using var connection = _context.CreateConnection();
                return await connection.QuerySingleOrDefaultAsync<DepartmentResponseDto>(sql, new { Id = id });
            }
            public async Task<bool> UpdateAsync(UpdateDepartmentRequestDto dto)
            {
                var sql = "UPDATE Departments SET DepartmentName = @DepartmentName WHERE DepartmentId = @DepartmentId;";
                using var connection = _context.CreateConnection();
                var affectedRows = await connection.ExecuteAsync(sql, dto);
                return affectedRows > 0;
            }

            public async Task<bool> DeleteAsync(int id)
            {
                var sql = "DELETE FROM Departments WHERE DepartmentId = @Id;";
                using var connection = _context.CreateConnection();
                var rows = await connection.ExecuteAsync(sql, new { Id = id });
                return rows > 0;
            }
     }
}
