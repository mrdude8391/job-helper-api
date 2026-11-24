namespace job_helper_api.Features.Auth.Utils;
public interface IPasswordHasher
{
    public string HashPassword(string password);
    public bool Verify(string passwordHash, string providedPassword);
}