using FrontEnd.Helpers;

namespace FrontEnd.Model.Dialog;

public class UserDialog
{
    public Select<DepartmentBl?>? Department { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public int RoleId { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime UpdateDate { get; set; }
}