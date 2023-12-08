namespace BackEnd.Models.Output
{
    public class MailBody
    {
        public int Id { get; }
        public string Name { get; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int UniversityId { get; set; }
    }
}
