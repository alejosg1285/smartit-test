using Application.Core;
using MediatR;

namespace Application.Commands.Hotel.AssignRoom;

public class AssignRoomHotelCommand : IRequest<Result<Unit>>
{
    /// <summary>
    /// Identification of the hotel
    /// </summary>
    public int HotelId { get; set; }

    /// <summary>
    /// Identification of the room
    /// </summary>
    public int RoomId { get; set; }
}
