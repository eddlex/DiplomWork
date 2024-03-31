using FrontEnd.Helpers;
using FrontEnd.Model.BL;

namespace FrontEnd.Model.Dialog;

public class FormDialog
{
    public Select<RecipientGroup> Group { get; set; }
    public string? Name { get; set; }
    public Select<DepartmentBl> Department { get; set; }
    public string? Description { get; set; }
}