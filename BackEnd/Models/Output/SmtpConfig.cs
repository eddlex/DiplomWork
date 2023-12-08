namespace BackEnd.Models.Output
{
    public class SmtpConfig
    {
        public int Id { get; }
        public int UniversityId { get; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSSL { get; set; }
    }
}
