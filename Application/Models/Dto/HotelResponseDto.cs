using System.ComponentModel.DataAnnotations;

namespace Application.Models.Dto;

public record HotelResponseDto
(
    string? Name,
    string? Description,
    string? Address,
    string? City
);
