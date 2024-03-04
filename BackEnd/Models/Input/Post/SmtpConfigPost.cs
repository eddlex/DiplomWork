using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class SmtpConfigPost
    {
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public string? SmtpServer { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool EnableSSL { get; set; }
    }
}
