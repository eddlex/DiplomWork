using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class RegistrationPost
    {
        [Required]
        [MaxLength(20)]
        [MinLength((5))]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        // [MaxLength(128)]
        // [MinLength(128)]
        public string Password { get; set; }
        
        [Required]
        public int UniversityId { get; set; }
        
        

    }
}
