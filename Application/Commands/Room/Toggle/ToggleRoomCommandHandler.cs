using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands.Room.Toggle;

public class ToggleRoomCommandHandler(ApplicationDbContext context) : IRequestHandler<ToggleRoomCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(ToggleRoomCommand request, CancellationToken cancellationToken)
    {
        Domain.Room roomDb = await _context.Rooms.FindAsync(request.Id);
        if (roomDb is null)
        {
            return null;
        }

        roomDb.IsActive = !roomDb.IsActive;
        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to active/inactive the room");

        return Result<Unit>.Success(Unit.Value);
    }
}
