namespace Application.Models.Dto;

/// <summary>
/// Object respond for the available search rooms
/// </summary>
/// <param name="HotelRoomId">Ientification of the relation hotel - room</param>
/// <param name="HotelName">Name of the hotel</param>
/// <param name="HotelAddress">Address of the hotel</param>
/// <param name="RoomName">Name of the room</param>
/// <param name="RoomDescription">Description of the room</param>
/// <param name="Location">Location of the room</param>
/// <param name="Price">Price of the room</param>
/// <param name="Taxes">Taxes of the room</param>
public record AvailableResponseDto
(
    int HotelRoomId,
    string HotelName,
    string HotelAddress,
    string RoomName,
    string RoomDescription,
    string Location,
    decimal Price,
    decimal Taxes
);
