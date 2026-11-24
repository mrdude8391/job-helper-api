using Microsoft.AspNetCore.Identity;

namespace job_helper_api.Features.Auth.Utils;
/// <summary>
/// Authentication utility that handles password hashing and hash verification. 
/// It builds off of the the PasswordHasher<> object provided by dotnet.
/// </summary>
public sealed class PasswordHasher : IPasswordHasher
{
    private static readonly object BlankUser = new(); 
    private readonly PasswordHasher<object> _hasher = new();
    public string HashPassword(string password)
    {
        return _hasher.HashPassword(BlankUser, password);
    }
    public bool Verify(string hashedPassword, string providedPassword)
    {
        var result = _hasher.VerifyHashedPassword(BlankUser, hashedPassword, providedPassword);
        return result != PasswordVerificationResult.Failed;
    }

}

