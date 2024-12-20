namespace Application.Models.Dto;

/// <summary>
/// Detail information of the book
/// </summary>
/// <param name="StartBook">Start date of the book</param>
/// <param name="EndBook">End date of the book</param>
/// <param name="Hotel">Hotel name of the book</param>
/// <param name="Room">Room name of the book</param>
/// <param name="Contact"><inheritdoc cref="ContactResponseDto" /></param>
/// <param name="Passengers"><inheritdoc cref="PassengerResponseDto" /></param>
public record BookDetailResponseDto
(
    DateTime StartBook,
    DateTime EndBook,
    HotelResponseDto Hotel,
    RoomResponseDto Room,
    ContactResponseDto Contact,
    List<PassengerResponseDto>? Passengers
);
