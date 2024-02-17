
namespace FrontEnd.Helpers;

public class Select<T> : ISelect
{
    private Dictionary<string, int>? Enum { get; set; } = new();
    
    public Select(string title, string bindPropertyName)
    {
        this.Title = title;
        this.BindPropertyName = bindPropertyName;
    }


    public Select(string title, string bindPropertyName, List<T>? list): this(title, bindPropertyName)
    {
        ConvertListToEnum(list);
    }

    
    public Dictionary<string, int>? Values
    {
        get => this.Enum;
        set => this.Enum = value;
    }


    private int _selectedValue;
    public int SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value || 
                string.IsNullOrWhiteSpace(this.BindPropertyName)) 
                return;
            
            _selectedValue = value;
             PropertyChanged?.Invoke(this.BindPropertyName, value);
        } 
    }
    
    public void ConvertListToEnum(List<T>? list)
    {
        
        var keyProperty = typeof(T).GetProperties()
            .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(CustomAttributes.EnumKeyAttribute)));

        var valueProperty = typeof(T).GetProperties()
            .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(CustomAttributes.EnumValueAttribute)));

        if (keyProperty == null || valueProperty == null)
        {
            throw Exception.Create("Reflaction Error");
        }

        foreach (T item in list)
        {
            try
            {
                var key = (string?)keyProperty.GetValue(item);
                var value = Convert.ToInt32(valueProperty.GetValue(item));
                this.Enum?.TryAdd(key, value);
            }
            catch
            {
                throw Exception.Create("Reflaction error");
            }

           
            
        }
    }
    public event ChangeEventHandler? PropertyChanged;
    public delegate void ChangeEventHandler(string propertyName, int newValue);

    public string? BindPropertyName { get; set; }
    public string? Title { get; set; }
}

public interface ISelect
{
    public  string? BindPropertyName { get; set; }
    public  string? Title { get; set; }

    public Dictionary<string, int>? Values { get; set; }
    
    public int SelectedValue { get; set; }

}