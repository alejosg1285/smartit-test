using Application.Core;
using MediatR;

namespace Application.Commands.Hotel.Create;

public class CreateHotelCommand : IRequest<Result<Unit>>
{
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
