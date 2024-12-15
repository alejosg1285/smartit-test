using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public record UserRegistrationDto
(
    [Required(ErrorMessage = "Name is required")] string DisplayName,
    [Required(ErrorMessage = "E-mail is required")][EmailAddress] string Email,
    [Required(ErrorMessage = "Password is required")] string Password,
    [Required(ErrorMessage = "Phone number is required")] string PhoneNumber,
    [Required(ErrorMessage = "Role name is required")] string RoleName
);
