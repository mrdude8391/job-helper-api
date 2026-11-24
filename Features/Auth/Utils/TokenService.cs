using System.Security.Claims;
using System.Text;
using job_helper_api.Entities;
using job_helper_api.Features.Auth.Options;
using job_helper_api.Features.Auth.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

public sealed class TokenService(IOptions<JwtOptions> options) : ITokenService
{
    private readonly JwtOptions _jwt = options.Value;
    public string GenerateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
           new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
           new Claim(JwtRegisteredClaimNames.Email, user.Email),
           new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = _jwt.Issuer,
            Audience = _jwt.Audience,
            Expires = DateTime.UtcNow.AddMinutes(_jwt.ExpiryMinutes),
            SigningCredentials = credentials,
        };

        return new JsonWebTokenHandler().CreateToken(descriptor);
    }
}