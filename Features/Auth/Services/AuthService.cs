using job_helper_api.Common.Exceptions;
using job_helper_api.Data;
using job_helper_api.Entities;
using job_helper_api.Features.Auth.DTOs;
using job_helper_api.Features.Auth.Utils;
using Microsoft.EntityFrameworkCore;

namespace job_helper_api.Features.Auth.Services;

public class AuthService(AppDbContext db, IPasswordHasher passwordHasher) : IAuthService
{
    public async Task<AuthResponse> RegisterAsync(UserRegisterRequest request)
    {
        string token = "";
        // 1. email
        string normalizedEmail = request.Email.Trim().ToLowerInvariant();
        if (await db.Users.AnyAsync(u => u.Email == normalizedEmail)) {
            throw new ConflictException("This email is already in use.");
        }
        // 2. hash pass
        string passwordHash = passwordHasher.HashPassword(request.Password);
        // 3. create user object + save
        User newUser = new User(normalizedEmail, passwordHash);
        db.Users.Add(newUser);
        await db.SaveChangesAsync();

        // 4. generate token
        return new AuthResponse(
            token
        );
    }
}