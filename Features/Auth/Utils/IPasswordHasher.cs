namespace job_helper_api.Features.Auth.Utils;
public interface IPasswordHasher
{
    /// <summary>
    /// Returns a hashed representation of the supplied <paramref name="password"/>.
    /// </summary>
    /// <param name="password">The supplied password</param>
    /// <returns>A hashed representation of the supplied <paramref name="password"/>.</returns>
    public string HashPassword(string password);
    /// <summary>
    /// Returns True if the supplied <paramref name="providedPassword" /> matches the stored <paramref name="hashedPassword"/>.
    /// </summary>
    /// <param name="hashedPassword">The hashed password stored in the database.</param>
    /// <param name="providedPassword">The hashed password supplied for comparison.</param>
    /// <returns>True if the supplied <paramref name="providedPassword"/> matches the stored <paramref name="hashedPassword"/>.</returns>
    public bool Verify(string hashedPassword, string providedPassword);
}