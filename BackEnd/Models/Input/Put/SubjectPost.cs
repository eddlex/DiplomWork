namespace BackEnd.Models.Input.Put;

public class SubjectPut
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public int OutcomeTypeId { get; set; }
    public int DepartmentId { get; set; }
}