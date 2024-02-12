using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using MudBlazor;

namespace FrontEnd.Helpers;

public class Select<T> 
{
    private readonly string? bindPropertyName;
    public readonly string? Title;
    private Dictionary<string, int>? Enum { get; set; } = new();
    
    public void Add(string key, int value)
    {
        this.Enum?.TryAdd(key, value);
    }

    public Select(string title, string bindPropertyName)
    {
        this.Title = title;
        this.bindPropertyName = bindPropertyName;
    }


    public Select(string title, string bindPropertyName, List<T>? list): this(title, bindPropertyName)
    {
        ConvertListToEnum(list);
    }

    
    
    public Dictionary<string, int>? Values => this.Enum;
    

    
    
    private int _selectedValue;
    public int SelectedValue
    {
        get => _selectedValue;
        set
        {
            if (_selectedValue == value || 
                string.IsNullOrWhiteSpace(this.bindPropertyName)) 
                return;
            
            _selectedValue = value;
            PropertyChanged?.Invoke(this.bindPropertyName, value);
        } 
    }
    // public int SelectedKey { get; set; }
         
    public void HandleSelectChanged(int code)
    { 
        this.SelectedValue = code;
    }
    
    
    private void ConvertListToEnum(List<T>? list)
    {
        
        var keyProperty = typeof(T).GetProperties()
            .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(CustomAttributes.EnumKeyAttribute)));

        var valueProperty = typeof(T).GetProperties()
            .FirstOrDefault(prop => Attribute.IsDefined(prop, typeof(CustomAttributes.EnumValueAttribute)));

        if (keyProperty == null || valueProperty == null)
        {
            throw new InvalidOperationException("Key and/or value attributes not found on type.");
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
    
}

internal class ValueAttribute
{
}