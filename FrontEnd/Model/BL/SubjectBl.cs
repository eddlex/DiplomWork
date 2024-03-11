using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class SubjectBl
{
    public int Id {  get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public int OutcomeType { get; set; }
    public int DepartmentId { get; set; }
}