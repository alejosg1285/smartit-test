using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dto;

/// <summary>
/// Information about the hotel
/// </summary>
/// <param name="Id">Identification of the hotel</param>
/// <param name="Name">Name of the hotel</param>
/// <param name="Description">Description of the hotel</param>
/// <param name="Address">Address of the hotel</param>
/// <param name="City">City of the hotel</param>
public record HotelResponseDto
(
    int Id,
    string? Name,
    string? Description,
    string? Address,
    string? City
);
