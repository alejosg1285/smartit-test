﻿namespace Application.Models.Dto;

/// <summary>
/// Information response of the room
/// </summary>
/// <param name="Id">Identification of the room</param>
/// <param name="Name">Name of the room</param>
/// <param name="Description">Description of the room</param>
/// <param name="Capacity">Number of person per room</param>
/// <param name="TypeRoom">Type of the room</param>
/// <param name="Price">Price bfore taxes of the room</param>
/// <param name="Taxes">Taxes of the room</param>
/// <param name="Location">Location of the room</param>
public record RoomResponseDto
(
    int Id,
    string? Name,
    string? Description,
    int Capacity,
    string? TypeRoom,
    decimal Price,
    decimal Taxes,
    string? Location
);
