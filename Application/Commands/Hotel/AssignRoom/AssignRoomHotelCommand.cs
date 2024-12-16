using Application.Core;
using MediatR;

namespace Application.Commands.Hotel.AssignRoom;

public class AssignRoomHotelCommand : IRequest<Result<Unit>>
{
    public int HotelId { get; set; }

    public int RoomId { get; set; }
}
