using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class FormBl
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public string? Name { get; set; }
    public int DepartmentId { get; set; }
    public string? Description { get; set; }
}