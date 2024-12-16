using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands.Room.Update;

public class UpdateRoomCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateRoomCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
    {
        Domain.Room roomDb = await _context.Rooms.FindAsync(request.Id);
        if (roomDb is null)
        {
            return null;
        }

        roomDb.Name = request.Name;
        roomDb.Description = request.Description;
        roomDb.TypeRoom = request.TypeRoom;
        roomDb.Capacity = request.Capacity;
        roomDb.Location = request.Location;
        roomDb.Price = request.Price;
        roomDb.Taxes = request.Taxes;

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to update the room");

        return Result<Unit>.Success(Unit.Value);
    }
}
