using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class RatingViewBl
{
    public int FromId { get; set; }
    public int FormRowId { get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public int RatingId { get; set; }
    public int RatingValue { get; set; }
}