namespace Application.Models.Dto;

/// <summary>
/// Contact information
/// </summary>
/// <param name="Name">Name of the contact</param>
/// <param name="LastName">Lastname of the contact</param>
/// <param name="PhoneNumber">Phone number of the contact</param>
public record ContactResponseDto
(
    string? Name,
    string? LastName,
    string? PhoneNumber
);
