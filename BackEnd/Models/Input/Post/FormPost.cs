namespace BackEnd.Models.Input
{
    public class FormPost
    {
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public string? Description { get; set; }
    }
}