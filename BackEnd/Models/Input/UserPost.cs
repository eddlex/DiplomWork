using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class UserPost
    {
        [Required]
        public string LogIn { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
