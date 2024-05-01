namespace FrontEnd.Model.DTO;

public class SubjectDtoForPage
{
    public int Id {  get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public string? OutcomeType { get; set; }
    public string? Department { get; set; }
    public int? HoursPerSem { get; set; }
    public float? SuggestedHours { get; set; }
}