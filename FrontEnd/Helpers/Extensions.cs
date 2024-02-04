using System.Security.Cryptography;
using System.Text;
using Blazored.SessionStorage;
using FrontEnd.Model;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace FrontEnd.Helpers;

public static class Extensions
{
    public static async Task SaveItem<T>(this ISessionStorageService sessionStorageService, string key, T item)
    {
       string itemJson = JsonConvert.SerializeObject(item);
       //
       var itemJsonBytes = Encoding.UTF8.GetBytes(itemJson);
         var base64Json = Convert.ToBase64String(itemJsonBytes);
         await sessionStorageService.SetItemAsStringAsync(key, base64Json);
        //await sessionStorageService.SetItemAsync(key, item);
    }

    public static async Task<UserSession?> GetItem(this ISessionStorageService sessionStorageService, string key)
    {
        
         //var item = await sessionStorageService.GetItemAsync<Object>(key)
         
         var base64Json = await sessionStorageService.GetItemAsStringAsync(key);
         if (base64Json == null)
             return null;
         var itemJsonBytes = Convert.FromBase64String(base64Json);
         var itemJson = Encoding.UTF8.GetString(itemJsonBytes);
         var item = JsonSerializer.Deserialize<UserSession>(itemJson);
         return item;
         
        
         
    }
    
    
    public static string ComputeSHA512Hash(this string input)
    {
        using (var sha512 = SHA512.Create())
        {
            // Convert the input string to bytes
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            // Compute the hash
            byte[] hashBytes = sha512.ComputeHash(inputBytes);

            // Convert the hash bytes to a string representation
            StringBuilder hashStringBuilder = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashStringBuilder.Append(b.ToString("X2"));
            }

            return hashStringBuilder.ToString();
        }
    }
}