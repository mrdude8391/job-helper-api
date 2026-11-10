using System.ComponentModel.DataAnnotations;

namespace job_helper_api.Features.Auth.DTOs;

public sealed record UserRegisterRequest(
    string Email,
    string Password,
    string ConfirmPassword
)
{ }