using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

/// <summary>
/// Object to authenticate a user
/// </summary>
/// <param name="Email">E-mail of the user</param>
/// <param name="Password">User`s password</param>
public record LoginDto
(
    [Required(ErrorMessage = "E-mail is mandatory")] string Email,
    [Required(ErrorMessage = "Password is required")] string Password
);
