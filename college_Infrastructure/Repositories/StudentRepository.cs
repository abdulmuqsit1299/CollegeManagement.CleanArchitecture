using college.Application.Interfaces;
using college.Domain.DTOs.Student;
using college.Domain.Entities;
using college.Infrastructure.Persistence;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext _context;

        public StudentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            var sql = "SELECT StudentID, FirstName, LastName, Email, DepartmentID FROM Students;";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<Student>(sql);
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            var sql = "SELECT StudentID, FirstName, LastName, Email, DepartmentID FROM Students WHERE StudentID = @Id;";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<Student>(sql, new { Id = id });
        }

        public async Task<int> CreateAsync(Student student)
        {
            var sql = @"INSERT INTO Students (FirstName, LastName, Email, DepartmentID)
                        VALUES (@FirstName, @LastName, @Email, @DepartmentID);
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, student);
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            var sql = @"UPDATE Students 
                        SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DepartmentID = @DepartmentID
                        WHERE StudentID = @StudentID;";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, student);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Students WHERE StudentID = @Id;";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }

        public Task<int> CreateAsync(CreateStudentRequestDto studentDto)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<StudentResponseDto>> IStudentRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<StudentResponseDto?> IStudentRepository.GetByIdAsync(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(UpdateStudentRequestDto studentDto)
        {
            throw new NotImplementedException();
        }
    }
}
