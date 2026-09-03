using Dapper;
using college.Application.Interfaces;
using college.Domain.DTOs.Course;
using college.Infrastructure.Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace college.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DapperContext _context;

        public CourseRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(CreateCourseRequestDto courseDto)
        {
            var sql = @"INSERT INTO Courses (CourseName, Credits, DepartmentId)
                        VALUES (@CourseName, @Credits, @DepartmentId);
                        SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(sql, courseDto);
                return id;
            }
        }

        public async Task<IEnumerable<CourseResponseDto>> GetAllAsync()
        {
            var sql = @"SELECT c.CourseId, c.CourseName, c.Credits, c.DepartmentId, d.DepartmentName
                        FROM Courses c
                        INNER JOIN Departments d ON c.DepartmentId = d.DepartmentId";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<CourseResponseDto>(sql);
            }
        }

        public async Task<CourseResponseDto?> GetByIdAsync(int courseId)
        {
            var sql = @"SELECT c.CourseId, c.CourseName, c.Credits, c.DepartmentId, d.DepartmentName
                        FROM Courses c
                        INNER JOIN Departments d ON c.DepartmentId = d.DepartmentId
                        WHERE c.CourseId = @CourseId";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<CourseResponseDto>(sql, new { CourseId = courseId });
            }
        }

        public async Task<bool> UpdateAsync(UpdateCourseRequestDto courseDto)
        {
            var sql = @"UPDATE Courses 
                        SET CourseName = @CourseName, Credits = @Credits, DepartmentId = @DepartmentId
                        WHERE CourseId = @CourseId";

            using (var connection = _context.CreateConnection())
            {
                var rows = await connection.ExecuteAsync(sql, courseDto);
                return rows > 0;
            }
        }

        public async Task<bool> DeleteAsync(int courseId)
        {
            var sql = "DELETE FROM Courses WHERE CourseId = @CourseId";

            using (var connection = _context.CreateConnection())
            {
                var rows = await connection.ExecuteAsync(sql, new { CourseId = courseId });
                return rows > 0;
            }
        }
    }
}
