namespace FrontEnd.Model;

public class ScheduleDto
{
    public int Id { get; set; }
    public string? Department { get; set; }
    public byte Semester { get; set; }
    public string? Name { get; set; }
    public int Hours { get; set; }
}