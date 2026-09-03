using System.ComponentModel.DataAnnotations;

namespace college.Domain.DTOs.Department
{
    public class CreateDepartmentRequestDto
    {
        [Required(ErrorMessage = "Department name is required")]
        [MaxLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
