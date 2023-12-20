using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

public static class JSRuntimeExtensions
{
    public static async Task Alert(this IJSRuntime jsRuntime, object message)
    {
        await jsRuntime.InvokeVoidAsync("alert", message);
    }
}