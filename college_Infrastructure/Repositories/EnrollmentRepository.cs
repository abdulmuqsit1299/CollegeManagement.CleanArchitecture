using college.Application.Interfaces;
using college.Domain.DTOs.Enrollment;
using college.Infrastructure.Persistence;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly DapperContext _context;

        public EnrollmentRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CreateEnrollmentRequestDto dto)
        {
            var sql = @"INSERT INTO Enrollments (StudentId, CourseId, EnrollmentDate) 
                        VALUES (@StudentId, @CourseId, @EnrollmentDate); 
                        SELECT CAST(SCOPE_IDENTITY() as int);";
            using var connection = _context.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(sql, dto);
        }

        public async Task<IEnumerable<EnrollmentResponseDto>> GetAllAsync()
        {
            var sql = "SELECT EnrollmentId, StudentId, CourseId, EnrollmentDate FROM Enrollments;";
            using var connection = _context.CreateConnection();
            return await connection.QueryAsync<EnrollmentResponseDto>(sql);
        }

        public async Task<EnrollmentResponseDto?> GetByIdAsync(int id)
        {
            var sql = "SELECT EnrollmentId, StudentId, CourseId, EnrollmentDate FROM Enrollments WHERE EnrollmentId = @Id;";
            using var connection = _context.CreateConnection();
            return await connection.QuerySingleOrDefaultAsync<EnrollmentResponseDto>(sql, new { Id = id });
        }

        public async Task<bool> UpdateAsync(UpdateEnrollmentRequestDto dto)
        {
            var sql = @"UPDATE Enrollments 
                        SET StudentId = @StudentId, CourseId = @CourseId, EnrollmentDate = @EnrollmentDate 
                        WHERE EnrollmentId = @EnrollmentId;";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, dto);
            return rows > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Enrollments WHERE EnrollmentId = @Id;";
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(sql, new { Id = id });
            return rows > 0;
        }
    }
}
