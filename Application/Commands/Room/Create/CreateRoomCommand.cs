using Application.Core;
using MediatR;

namespace Application.Commands.Room.Create;

public class CreateRoomCommand : IRequest<Result<Unit>>
{
    /// <summary>
    /// Name of the room
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Description of the room
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Number of person per room
    /// </summary>
    public int Capacity { get; set; }

    /// <summary>
    /// Type of the room
    /// </summary>
    public string? TypeRoom { get; set; }

    /// <summary>
    /// Price before taxes of the room
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Taxes of the room
    /// </summary>
    public decimal Taxes { get; set; }

    /// <summary>
    /// Location of the room
    /// </summary>
    public string? Location { get; set; }
}
