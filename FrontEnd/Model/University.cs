using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace FrontEnd.Model;

public class University
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public University(int id, string name, string description)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
    }
}