namespace BackEnd.Models.Output;

public class FormRowDelete
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string? Query { get; set; }
    public bool Required { get; set; }
}