using FrontEnd.Helpers;
using FrontEnd.Model.BL;

namespace FrontEnd.Model.Dialog;

public class ScheduleDialog
{
    public Select<DepartmentBl> Department { get; set; }
    public byte Semester { get; set; } = 1;
    public string? Name { get; set; }
    public int Hours { get; set; } = 1;
}