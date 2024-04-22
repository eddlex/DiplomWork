using System.Text;
public class RequestResponseLoggingMiddleware
{
    private readonly RequestDelegate next;
    
    public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Capture the request information
        var requestInfo = await FormatRequest(context.Request);
        
        if (!string.IsNullOrWhiteSpace(requestInfo))
        {
            await LogToFile($"Request: {requestInfo}");
        }

        // Capture the original response body stream
        var originalResponseBodyStream = context.Response.Body;

        // Create a new memory stream to capture the response body
        await using var responseBodyStream = new MemoryStream();
        // Replace the response body with the memory stream
        context.Response.Body = responseBodyStream;

        // Proceed with processing the request pipeline
        await next(context);

        // Rewind the memory stream to read its content
        responseBodyStream.Seek(0, SeekOrigin.Begin);

        // Read the response body from the memory stream
        var responseBody = await new StreamReader(responseBodyStream).ReadToEndAsync();

        // Log the response information
        var responseInfo = $"Status code: {context.Response.StatusCode}, Body: {responseBody}";
        if (!string.IsNullOrWhiteSpace(requestInfo))
        {
            await LogToFile($"Response: {responseInfo}");
        }
            
            

        // Copy the captured response body back to the original response stream
        responseBodyStream.Seek(0, SeekOrigin.Begin);
        await responseBodyStream.CopyToAsync(originalResponseBodyStream);

        // Restore the original response body stream
        context.Response.Body = originalResponseBodyStream;
    }

    private async Task<string> FormatRequest(HttpRequest request)
    {
        // Reading the request body
        string requestBody;
        request.EnableBuffering();
        using (StreamReader reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true))
        {
            requestBody = await reader.ReadToEndAsync();
        }
        request.Body.Seek(0, SeekOrigin.Begin);
        
        if (request.Path.HasValue && request.Path.Value.Contains("swagger"))
            return "";
        // Constructing request information string
        var requestInfo = $"Path: {request.Path}, QueryString: {request.QueryString}, Method: {request.Method}, Headers: {request.Headers}, Body: {requestBody}";

        return requestInfo;
    }

    private async Task LogToFile(string message)
    {
        // Define the log file path
        string logFilePath = $"Log/log_{DateTime.Now.Date.Year}_{DateTime.Now.Date.Month}_{DateTime.Now.Date.Day}.txt"; // Adjust the log file path as needed

        if (!Directory.Exists("Log"))
        {
            Directory.CreateDirectory("Log");
        }

        using (var writer = new StreamWriter(logFilePath, append: true))
        {
           await writer.WriteLineAsync($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {message}");
        }
    }
}