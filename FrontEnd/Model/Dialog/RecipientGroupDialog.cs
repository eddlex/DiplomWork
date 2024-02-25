using FrontEnd.Helpers;
using FrontEnd.Model.BL;

namespace FrontEnd.Model.Dialog;

public class RecipientGroupDialog
{
    public string? Name { get; set; }
    public Select<Department> Department { get; set; }
    public string? Description { get; set; }
}