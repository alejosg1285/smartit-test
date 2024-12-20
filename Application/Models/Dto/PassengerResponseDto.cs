using Domain;

namespace Application.Models.Dto;

/// <summary>
/// Basic information of the passenger
/// </summary>
/// <param name="Name">Name of the passenger</param>
/// <param name="LastName">Lastname of the passenger</param>
/// <param name="Genre">Gender of the passenger</param>
/// <param name="IdentificationType">Identification type of the passenger</param>
/// <param name="IdentificationNumber">Identification number of the passenger</param>
/// <param name="Email">E-mail of the passenger</param>
/// <param name="PhoneNumber">Phone number of the passenger</param>
public record PassengerResponseDto
(
    string? Name,
    string? LastName,
    GenderEnum Genre,
    string? IdentificationType,
    string? IdentificationNumber,
    string? Email,
    string? PhoneNumber
);
