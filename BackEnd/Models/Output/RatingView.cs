﻿namespace BackEnd.Models.Output;

public class RatingView
{
    public int FormId { get; set; }
    public int FormRowId { get; set; }
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    
    public int RatingId { get; set; }
    public int RatingValue { get; set; }
}