using System.ComponentModel.DataAnnotations;
using TASK_poiner.models;

namespace TASK_poiner.DTOS
{
    public class EmployeeDTO
    {
        public int EmployeeId { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 5 and 50 characters.")]
        public string Name { get; set; }
        public string Code { get; set; }

        [Required]
        public ICollection<PropertyDTO> CustomProperteis { get; set; } 
    }
}
