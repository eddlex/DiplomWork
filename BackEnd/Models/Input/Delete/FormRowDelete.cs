namespace BackEnd.Models.Output;

public class FormRowDelete
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int SubjectId { get; set; }
    public bool Order { get; set; }
}