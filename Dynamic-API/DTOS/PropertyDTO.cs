using System.ComponentModel.DataAnnotations;
using TASK_poiner.models;

namespace TASK_poiner.DTOS
{
    public class PropertyDTO
    {
        public int PropertyId { get; set; }
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 5 and 50 characters.")]
        public string Name { get; set; }
        [Required]
        public string Value { get; set; }
        public List<string>? DropdownOptions { get; set; }
        public PropertyType Type { get; set; }
    }
}
