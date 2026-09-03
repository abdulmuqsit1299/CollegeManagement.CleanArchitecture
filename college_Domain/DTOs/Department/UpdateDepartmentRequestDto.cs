using System.ComponentModel.DataAnnotations;

namespace college.Domain.DTOs.Department
{
    public class UpdateDepartmentRequestDto
    {
        [Required]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [MaxLength(100)]
        public string DepartmentName { get; set; } = string.Empty;
    }
}
