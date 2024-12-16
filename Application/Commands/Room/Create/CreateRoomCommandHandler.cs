using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands.Room.Create;

public class CreateRoomCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateRoomCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
    {
        Domain.Room room = new Domain.Room
        {
            Name = request.Name,
            Description = request.Description,
            TypeRoom = request.TypeRoom,
            Capacity = request.Capacity,
            Location = request.Location,
            Price = request.Price,
            Taxes = request.Taxes,
            IsActive = true,
        };
        _context.Rooms.Add(room);
        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to create the room");

        return Result<Unit>.Success(Unit.Value);
    }
}
