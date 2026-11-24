using Microsoft.AspNetCore.Identity;

namespace job_helper_api.Features.Auth.Utils;

public sealed class PasswordHasher : IPasswordHasher
{
    private static readonly object BlankUser = new(); 
    private readonly PasswordHasher<object> _hasher = new();
    public string HashPassword(string password)
    {
        return _hasher.HashPassword(BlankUser, password);
    }
    public bool Verify(string passwordHash, string providedPassword)
    {
        var result = _hasher.VerifyHashedPassword(BlankUser, passwordHash, providedPassword);
        return result != PasswordVerificationResult.Failed;
    }

}

