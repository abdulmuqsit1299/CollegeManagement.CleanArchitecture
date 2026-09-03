namespace college.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        //Relation
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
