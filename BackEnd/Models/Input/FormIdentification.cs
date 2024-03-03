namespace BackEnd.Models.Input
{
    public class FormIdentification
    {
        public Guid Id { get; set; }
        public int FormId { get; set; }
        public int GroupId { get; set; }
        public int RecipientId { get; set; }
        public int Status { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public DateTime CreationTime { get; set; }
    }
}