using job_helper_api.Features.Auth.DTOs;

namespace job_helper_api.Features.Auth;
public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(UserRegisterRequest request);
}