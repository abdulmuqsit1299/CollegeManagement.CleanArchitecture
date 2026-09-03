namespace college.Domain.DTOs.Student
{
    public class StudentResponseDto
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string DepartmentName { get; set; } = string.Empty;
    }
}
