using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.DTO;

public class FormRowDto
{
    public int Id { get; set; }
    public int FomId { get; set; }
    public string? Name { get; set; }
    public int Value { get; set; }
}