namespace Application.Models.Dto;

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
