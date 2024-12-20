using Application.Core;
using MediatR;

namespace Application.Commands.Hotel.Update;

public class UpdateHotelCommand : IRequest<Result<Unit>>
{
    /// <summary>
    /// Identification object of the hotel
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the hotel
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Description of the hotel
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Main address of the hotel
    /// </summary>
    public string? Address { get; set; }

    /// <summary>
    /// City of the hotel
    /// </summary>
    public string? City { get; set; }
}
