namespace job_helper_api.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password_Hash { get; set; } = string.Empty;
    public DateTime Created_At { get; set; }
}