using System.ComponentModel.DataAnnotations;
using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class Weight
{
    [CustomAttributes.EnumValue]
    public int Id { get; set; }
    
    
    [CustomAttributes.EnumKey]
    public string Name { get; set; }
    public float Value { get; set; }
    
    public Weight(int id, string name, float value)
    {
        this.Id = id;
        this.Name = name;
        this.Value = value;
    }
}

