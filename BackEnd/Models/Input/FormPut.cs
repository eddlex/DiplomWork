namespace BackEnd.Models.Input
{
    public class FormPut
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string? Name { get; set; }
        public int DepartmentId { get; set; }
        public string? Description { get; set; }
    }
}