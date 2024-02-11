using System.Net.Sockets;
using MudBlazor;

namespace FrontEnd.Helpers;

public class Select 
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
    
    public event ChangeEventHandler? PropertyChanged;
    public delegate void ChangeEventHandler(string propertyName, int newValue);
    
}