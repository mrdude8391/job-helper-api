using job_helper_api.Entities;

namespace job_helper_api.Features.Auth.Utils;
/// <summary>
/// Handles generating access token from a user object.
/// </summary>
public interface ITokenService
{
    /// <summary>
    /// Creates a Jwt access token from the supplied user object.
    /// </summary>
    /// <param name="user"></param>
    /// <returns>A string type access token from the <paramref name="user"/> object </returns>
    public string GenerateAccessToken(User user);
}