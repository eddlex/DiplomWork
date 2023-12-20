using FrontEnd.Interface;

namespace FrontEnd.API;

public class ConfigurationService :IConfigurationService
{
    public string WWW { get => $"https://localhost:{PORT}/"; set => WWW = value; }
    public string PORT { get => "7154"; set => PORT = value; } 
    
    
}