using job_helper_api.Features.Auth.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace job_helper_api.Controllers;

/// <summary>
/// TEMPORARY: exists only to test ValidationFilter by hand. Delete before committing.
/// </summary>
[ApiController]
[Route("api/debug")]
public class DebugController : ControllerBase
{
    // If this action runs, ValidationFilter already approved the request.
    [HttpPost("register")]
    public IActionResult Register(UserRegisterRequest request)
    {
        return Ok(request);
    }
}
