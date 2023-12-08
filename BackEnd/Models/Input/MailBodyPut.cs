namespace BackEnd.Models.Input
{
    public class MailBodyPut
    {
        public int Id { get; }
        public string Name { get; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public int UniversityId { get; set; }
    }
}
