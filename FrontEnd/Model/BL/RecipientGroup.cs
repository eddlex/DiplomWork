using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class RecipientGroup
{
    [CustomAttributes.EnumValue]
    public int     Id           { get; set; }
    
    [CustomAttributes.EnumKey]
    public string? Name         { get; set; }
    
    public int     DepartmentId { get; set; }
    public string? Description  { get; set; }
}