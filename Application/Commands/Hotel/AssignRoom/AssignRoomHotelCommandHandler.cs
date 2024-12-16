using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.Commands.Hotel.AssignRoom;

public class AssignRoomHotelCommandHandler(ApplicationDbContext context) : IRequestHandler<AssignRoomHotelCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(AssignRoomHotelCommand request, CancellationToken cancellationToken)
    {
        Domain.Hotel hotelDb = await _context.Hotels.FindAsync(request.HotelId);
        if (hotelDb is null)
        {
            return null;
        }

        Domain.Room roomDb = await _context.Rooms.FindAsync(request.RoomId);
        if (roomDb is null)
        {
            return null;
        }

        Domain.HotelRoom hotelRoom = new()
        {
            HotelId = hotelDb.Id,
            RoomId = roomDb.Id
        };
        _context.HotelRoom.Add(hotelRoom);
        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to assign the room to the hotel");

        return Result<Unit>.Success(Unit.Value);
    }
}
