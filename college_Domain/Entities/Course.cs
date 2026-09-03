namespace college.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int Credits { get; set; }


        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    }
}
