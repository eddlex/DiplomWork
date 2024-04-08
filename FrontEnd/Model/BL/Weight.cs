using FrontEnd.Helpers;

namespace FrontEnd.Model.BL;

public class OutcomeType
{
    [CustomAttributes.EnumValue]
    public int Id { get; set; }
    
    
    [CustomAttributes.EnumKey]
    public string? Title { get; set; }

    
    public OutcomeType(int id, string title)
    {
        this.Id = id;
        this.Title = title;
    }
}

