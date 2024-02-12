using FrontEnd.Helpers;
using FrontEnd.Model.BL;

namespace FrontEnd.Model.Dialog;

public class RecipientDialog
{
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public Select<RecipientGroup> Group { get; set; }

    public Select<Department> Department { get; set; }

    public string? Description { get; set; }
}