using System;

namespace college.Domain.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        // Foreign key to Student
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        // Extra
        public DateTime EnrollmentDate { get; set; }
    }
}
