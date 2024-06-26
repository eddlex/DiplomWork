﻿using FrontEnd.Helpers;
using FrontEnd.Model.BL;

namespace FrontEnd.Model.Dialog;

public class SubjectDialog
{
    public string? Title { get; set; }
    public string? Outcome { get; set; }
    public Select<OutcomeType>? OutcomeType { get; set; }
    public Select<DepartmentBl>? Department { get; set; }
    public int HoursPerSem { get; set; }
}