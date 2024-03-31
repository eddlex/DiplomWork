using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input.Put;
public class DepartmentPut
{
    [Required]
    [Range(0, int.MaxValue)]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Name { get; set; }
    public string? Description { get; set; }
}

