using System;

namespace college.Domain.DTOs.Enrollment
{
    public class EnrollmentResponseDto
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
