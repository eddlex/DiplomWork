using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class DepartmentPost
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
