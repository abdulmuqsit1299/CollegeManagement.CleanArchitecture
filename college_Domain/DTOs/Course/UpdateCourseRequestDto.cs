namespace college.Domain.DTOs.Course
{
    public class UpdateCourseRequestDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
