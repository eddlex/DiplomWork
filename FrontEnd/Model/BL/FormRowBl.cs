using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class FormRowBl
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public int SubjectId { get; set; } 
    public int Order { get; set; } 
}