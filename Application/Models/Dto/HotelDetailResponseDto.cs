namespace Application.Models.Dto;

/// <summary>
/// Detail information about the hotel
/// </summary>
/// <param name="Id">Identification of the hotel</param>
/// <param name="Name">Name of the hotel</param>
/// <param name="Description">Descripction of the hotel</param>
/// <param name="Address">Main address of the hotel</param>
/// <param name="City">City of the hotel</param>
/// <param name="Rooms"><inheritdoc cref="RoomResponseDto" /></param>
public record HotelDetailResponseDto
(
    int Id,
    string? Name,
    string? Description,
    string? Address,
    string? City,
    List<RoomResponseDto> Rooms
);
