namespace Application.Models.Dto;

public record BookDetailResponseDto
(
    DateTime StartBook,
    DateTime EndBook,
    HotelResponseDto Hotel,
    RoomResponseDto Room,
    ContactResponseDto Contact,
    List<PassengerResponseDto>? Passengers
);
