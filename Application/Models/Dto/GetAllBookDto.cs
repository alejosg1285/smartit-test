namespace Application.Models.Dto;

/// <summary>
/// Basic information of the book
/// </summary>
/// <param name="Id">Identification of the book</param>
/// <param name="StartBook">Start date of the book</param>
/// <param name="EndBook">End date of the book</param>
/// <param name="HotelName">Hotel name of the book</param>
/// <param name="RoomName">Room name of the book</param>
public record GetAllBookDto
(
    int Id,
    DateTime StartBook,
    DateTime EndBook,
    string? HotelName,
    string? RoomName
);
