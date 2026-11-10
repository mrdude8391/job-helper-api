using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace job_helper_api.Common.Filters;
/// <summary>
/// This filter will run before every controller action. 
/// This filter will validate the DTO arguments before they touch the controllers
/// </summary>
public class ValidationAsyncFilter : IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context, ActionExecutionDelegate next)
    {
        // Do something before the action executes.
        // A. Get the arguments provided to the controller, ie. the DTO, Action filter runs after model binding.
        foreach (var argument in context.ActionArguments.Values)
        {
            if (argument is null) continue;
            // B. Get the validator dynamically from registered services. 
            // To get validator we need the type of argument. i.e RegisterRequest and RegisterRequestValidator
            Type argumentType = argument.GetType();
            Type openValidatorType = typeof(IValidator<>);
            Type validatorType = openValidatorType.MakeGenericType(argumentType);

            var validator = context.HttpContext.RequestServices.GetService(validatorType) as IValidator;

            if (validator is null) continue;
            // C. Perform validation on argument
            // Since the validator is an interface version and not generic with our required type, we need to pass in the correct ValidationContext
            var validationContext = new ValidationContext<object>(argument);
            ValidationResult result = await validator.ValidateAsync(validationContext, context.HttpContext.RequestAborted);

            foreach (var error in result.Errors)
            {
                context.ModelState.AddModelError(
                    error.PropertyName,
                    error.ErrorMessage
                );
            }
        }

        if (!context.ModelState.IsValid)
        {
            var problemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "One or more validation errors occurred."
            };

            context.Result = new ObjectResult(problemDetails)
            {
                StatusCode = StatusCodes.Status400BadRequest
            };

            return;
        }

        await next();
        // Do something after the action executes.
    }
}