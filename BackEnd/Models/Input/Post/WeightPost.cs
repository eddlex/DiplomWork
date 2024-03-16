using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class WeightPost
    {
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }
        public float Value { get; set; }
    }
}
