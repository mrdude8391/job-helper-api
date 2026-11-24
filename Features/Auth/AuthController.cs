using job_helper_api.Features.Auth.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace job_helper_api.Features.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterRequest request)
    {
        // call the service, return 201 with the response
        return Ok(await authService.RegisterAsync(request));
    }
}