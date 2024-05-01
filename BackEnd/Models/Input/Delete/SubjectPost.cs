namespace BackEnd.Models.Input.Delete;

public class SubjectDelete
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public int OutcomeTypeId { get; set; }
    public int DepartmentId { get; set; }
    public int? HoursPerSem { get; set; }
    public float? SuggestedHours { get; set; }
}