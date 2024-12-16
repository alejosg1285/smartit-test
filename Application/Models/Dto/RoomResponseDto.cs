using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dto;

public record RoomResponseDto
(
    string? Name,
    string? Description,
    int Capacity,
    string? TypeRoom,
    decimal Price,
    decimal Taxes,
    string? Location
);
