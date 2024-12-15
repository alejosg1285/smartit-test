using System.ComponentModel.DataAnnotations;

namespace Api.Dto;

public record LoginDto
(
    [Required(ErrorMessage = "E-mail is mandatory")] string Email,
    [Required(ErrorMessage = "Password is required")] string Password
);
