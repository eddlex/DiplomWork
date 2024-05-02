using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class SuggestionBl
{
    public int Id { get; set; }
    public int FormIdentificationId { get; set; }
    public string? Value { get; set; }
}