namespace Application.Models.Dto;

/// <summary>
/// Contact object to the book
/// </summary>
/// <param name="Name">Name of the contact</param>
/// <param name="LastName">Last name of the contact</param>
/// <param name="PhoneNumber">Phone numbe of the contact</param>
public record ContactRequestDto
(
    string? Name,
    string? LastName,
    string? PhoneNumber
);
