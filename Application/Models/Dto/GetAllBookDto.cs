namespace Application.Models.Dto;

public record GetAllBookDto
(
    int Id,
    DateTime StartBook,
    DateTime EndBook,
    string? HotelName,
    string? RoomName
);
