using System;
using System.ComponentModel.DataAnnotations;

namespace college.Domain.DTOs.Enrollment
{
    public class CreateEnrollmentRequestDto
    {
        [Required]
        public int StudentId { get; set; }

        [Required]
        public int CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}
