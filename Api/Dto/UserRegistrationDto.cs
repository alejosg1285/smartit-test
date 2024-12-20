using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

/// <summary>
/// Object to register a new user
/// </summary>
/// <param name="DisplayName">Name of the user</param>
/// <param name="Email">E-mail, works as Username</param>
/// <param name="Password">Password to authenticate</param>
/// <param name="PhoneNumber">Phone number</param>
/// <param name="RoleName">Role to assign to the user, Admin or Traveller</param>
public record UserRegistrationDto
(
    [Required(ErrorMessage = "Name is required")] string DisplayName,
    [Required(ErrorMessage = "E-mail is required")][EmailAddress] string Email,
    [Required(ErrorMessage = "Password is required")] string Password,
    [Required(ErrorMessage = "Phone number is required")] string PhoneNumber,
    [Required(ErrorMessage = "Role name is required")] string RoleName
);
