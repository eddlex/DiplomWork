using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class RatingPost
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int FormIdentificationId { get; set; }

        public List<RatingRowPost> RatingRows { get; set; }
    }
    
    
    public class RatingRowPost
    {
        public int Id { get; set; }
        public int FormRowId { get; set; }
        public decimal Value { get; set; }
    }
    
    
    
}