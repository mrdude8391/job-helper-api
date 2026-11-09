using Microsoft.AspNetCore.Diagnostics;

public class GlobalExceptionHanlder(
    IProblemDetailsService problemDetailsService,
    ILogger<GlobalExceptionHanlder> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        // Map exception to HTTP status code.
        // Return a consistent ProblemDetails response.

        return true;
    }
}