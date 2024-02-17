using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class RegistrationPost
{
    public string? UserName     { get; set; }
    public string? Email        { get; set; }
    public string? Password     { get; set; }
    public int     DepartmentId { get; set; }
    
      
}