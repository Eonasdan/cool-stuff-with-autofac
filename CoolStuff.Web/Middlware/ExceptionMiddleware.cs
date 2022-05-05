using JetBrains.Annotations;

namespace CoolStuff.Web.Middlware;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly ILogger _logger;

    public ExceptionHandlerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory,
        IWebHostEnvironment webHostEnvironment)
    {
        _next = next;
        _webHostEnvironment = webHostEnvironment;
        _logger = loggerFactory.CreateLogger<ExceptionHandlerMiddleware>();
    }

    [UsedImplicitly]
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Application error");

            if (context.Request.Path.HasValue && context.Request.Path.Value.StartsWith("/api/"))
            {
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsJsonAsync(new
                {
                    context.Response.StatusCode,
                    Message = _webHostEnvironment.IsDevelopment() ? ex.Message : "Something when wrong",
                    Stacktrace = _webHostEnvironment.IsDevelopment() ? ex.StackTrace : ""
                });
                return;
            }
            throw; // Re-throw the original if we couldn't handle it
        }
    }
}