using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using FrontEnd.Interface;
using FrontEnd.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace FrontEnd.API;

public class AuthorizationService : IAuthorizationService
{
    public AuthorizationService(HttpClient httpClient, IConfigurationService configurationService)
    {
        HttpClient = httpClient;
        ConfigurationService = (ConfigurationService)configurationService;
    }


     protected HttpClient HttpClient { get; set; }
    //
  
     protected IConfigurationService ConfigurationService { get ; set; }
    
    
    public async Task<string> AuthorizeClient(AuthorizationPost input)
    {
        
        try
        {
            var content = new StringContent(JsonSerializer.Serialize(input), Encoding.UTF8, "application/json");
            
            var response = await this.HttpClient.PostAsync(ConfigurationService.WWW + "Security/Authorize", content);
            
            
            if (response.IsSuccessStatusCode)
            {
                // Handle successful response
                var responseBody = await response.Content.ReadAsStringAsync();
                // Process the response data as needed
            }
            else
            {
                // Handle unsuccessful response
                var errorMessage = await response.Content.ReadAsStringAsync();
                // Handle the error message or perform error handling
            }

        }
        catch (Exception e)
        {

        }
        finally
        { 
            
        }

        return "ds";

    }
    
    
    
}