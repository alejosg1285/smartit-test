using Domain;

namespace Application.Models.Dto;

public record PassengerRequestDto
(
    string? Name,
    string? LastName,
    GenderEnum Genre,
    string? IdentificationType,
    string? IdentificationNumber,
    string? Email,
    string? PhoneNumber
);
