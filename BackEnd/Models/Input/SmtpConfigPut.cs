namespace BackEnd.Models.Input
{
    public class SmtpConfigPut
    {
        public int Id { get; set; }
        public int UniversityId { get; }
        public string? SmtpServer { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? EnableSSL { get; set; } = true;
    }
}
