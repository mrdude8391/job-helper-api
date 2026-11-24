using job_helper_api.Features.Auth.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace job_helper_api.Features.Auth;

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<AuthResponse>> Register(UserRegisterRequest request)
    {
        var response = await authService.RegisterAsync(request);
        return StatusCode(StatusCodes.Status201Created, response);
    }
}