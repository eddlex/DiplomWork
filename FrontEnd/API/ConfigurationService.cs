using FrontEnd.Interface;

namespace FrontEnd.API;

public static class ConfigurationService //:IConfigurationService
{
    public static string URL { get => $"https://localhost:{PORT}/"; /*set => URL = value;*/ }
    public static string PORT { get => "44301"; /*set => PORT = value; */} 
}


