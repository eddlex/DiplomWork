namespace BackEnd.Models.Output;
public class Schedule
{
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public byte Semester { get; set; }
        public string? Name { get; set; }
        public int Hours { get; set; }
}