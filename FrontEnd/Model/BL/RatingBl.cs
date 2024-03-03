using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class RatingBl
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public int Weight { get; set; }
}