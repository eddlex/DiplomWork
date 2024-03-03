using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Output;

public class FormRowPut
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int FormId { get; set; }
    [Required]
    public string? Query { get; set; }
    [Required]
    public bool Required { get; set; }
}