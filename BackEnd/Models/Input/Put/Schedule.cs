namespace BackEnd.Models.Input;
public class SchedulePut
{
    public int Id { get; set; }
    public int DepartmentId { get; set; }
    public byte Semester { get; set; }
    public string? Name { get; set; }
    public int Hours { get; set; }
}