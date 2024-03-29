﻿using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class UserPost
    {
        [Required]
        [MaxLength(20)]
        [MinLength((5))]
        public string LogIn { get; set; }

        [Required]
        // [MaxLength(128)]
        // [MinLength(128)]
        public string Password { get; set; }

    }
}
