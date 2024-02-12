namespace FrontEnd.Helpers;

public abstract class HandleSelectChange
{
    public void Suscribe<T>(Select<T> secondElement)
    {
        secondElement.PropertyChanged += (string propertyName, int newValue) =>
        {
            var propertyInfo = this.GetType().GetProperty(propertyName);
            propertyInfo?.SetValue(this, newValue);   
        };
    }

           
}