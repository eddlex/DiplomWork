using FrontEnd.Helpers;

namespace FrontEnd.Model;

public class RegistrationPost
{
    public string UserName     { get; set; }
    public string Email        { get; set; }
    public string Password     { get; set; }
    public int    DepartmentId { get; set; }
    
    public void Suscribe(Select secondElement)
    {
        secondElement.PropertyChanged += HandleSelectChange;
    }
    
    private void HandleSelectChange(string propertyName, int newValue)
    {
        var propertyInfo = this.GetType().GetProperty(propertyName);
        propertyInfo?.SetValue(this, newValue);   
    }        
}