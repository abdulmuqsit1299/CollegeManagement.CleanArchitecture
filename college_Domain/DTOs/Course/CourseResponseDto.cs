namespace college.Domain.DTOs.Course
{
    public class CourseResponseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty; // join me kaam aayega
    }
}
