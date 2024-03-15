using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Output;

public class FormRowPost
{
    [Required]
    public int FormId { get; set; }
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public int Order { get; set; }
}