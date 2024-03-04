using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models.Input
{
    public class SmtpConfigDelete
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int DepartmentId { get; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public bool EnableSSL { get; set; }
    }
}
