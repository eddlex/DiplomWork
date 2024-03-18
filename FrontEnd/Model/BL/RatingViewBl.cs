using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class RatingViewBl
{
    public int Id { get; set; }
    public int FormId { get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public int Rating { get; set; }
}