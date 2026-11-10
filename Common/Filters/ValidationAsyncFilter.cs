using Microsoft.AspNetCore.Mvc.Filters;

namespace job_helper_api.Common.Filters;

public class ValidationAsyncFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Do something before the action executes.
        await next();
        // Do something after the action executes.
    }
}