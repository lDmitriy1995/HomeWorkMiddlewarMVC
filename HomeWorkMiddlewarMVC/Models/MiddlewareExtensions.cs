using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder app, string logFilePath)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>(logFilePath);
    }
}

public class Startup
{
    // ...

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ...

        string logFilePath = "requests.log";
        app.UseRequestLoggingMiddleware(logFilePath);

        // ...
    }
}
