using FrontEnd.Helpers;

namespace FrontEnd.Model.DTO;

public class RecipientGroupDto
{
    [CustomAttributes.EnumValue]
    public int     Id           { get; set; }
    
    [CustomAttributes.EnumKey]
    public string? Name         { get; set; }
    
    public string?   Department { get; set; }
    public string? Description  { get; set; }
}