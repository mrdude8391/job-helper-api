using System.ComponentModel.DataAnnotations;

namespace job_helper_api.Features.Auth.Options;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    [Required]
    public string Issuer { get; set; } = string.Empty;

    [Required]
    public string Audience { get; set; } = string.Empty;
    
    [Range(1,60)]
    public int ExpiryMinutes { get; set; } = 15;
    
    [Required, MinLength(32, ErrorMessage = "Key length must be at least 32 characters.")]
    public string Key { get; set; } = string.Empty;
}