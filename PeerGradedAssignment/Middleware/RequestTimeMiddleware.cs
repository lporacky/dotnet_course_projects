namespace Backend.Middleware;

public class RequestTimeMiddleware
{
    private readonly RequestDelegate _next;

    public RequestTimeMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var startTime = DateTime.Now;

        await _next(context);

        var duration = DateTime.Now - startTime;

        Console.WriteLine($"Request completed in {duration.TotalMilliseconds} ms");
    }
}