using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class SuggestionBl
{
    public int Id { get; set; }
    public string? Suggestion { get; set; }
}