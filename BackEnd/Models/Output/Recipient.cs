namespace BackEnd.Models.Input
{
    public class Recipient
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Mail { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
