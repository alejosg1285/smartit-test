using Domain;

namespace Application.Models.Dto;

/// <summary>
/// Detail information of the room
/// </summary>
/// <param name="Id">Identification of the room</param>
/// <param name="Name">Name of the room</param>
/// <param name="Description">Description of the room</param>
/// <param name="Capacity">Number of person per room</param>
/// <param name="TypeRoom">Type of the room</param>
/// <param name="Price">Price before taxes of the room</param>
/// <param name="Taxes">Taxes of the room</param>
/// <param name="Location">Location of the room</param>
/// <param name="Hotels"><inheritdoc cref="HotelResponseDto" /></param>
public record RoomDetailResponseDto
(
    int Id,
    string? Name,
    string? Description,
    int Capacity,
    string? TypeRoom,
    decimal Price,
    decimal Taxes,
    string? Location,
    List<HotelResponseDto> Hotels
);
