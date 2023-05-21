using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly string _logFilePath;

    public RequestLoggingMiddleware(RequestDelegate next, string logFilePath)
    {
        _next = next;
        _logFilePath = logFilePath;
    }

    public async Task Invoke(HttpContext context)
    {
        string requestPath = context.Request.Path;
        string logMessage = $"[{DateTime.Now}] Requested path: {requestPath}";

        using (StreamWriter writer = new StreamWriter(_logFilePath, append: true))
        {
            await writer.WriteLineAsync(logMessage);
        }

        await _next(context);
    }
}
