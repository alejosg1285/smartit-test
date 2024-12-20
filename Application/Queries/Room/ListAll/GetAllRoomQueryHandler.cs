using Application.Core;
using Application.Models.Dto;
using MediatR;
using Persistence;

namespace Application.Queries.Room.ListAll;

public class GetAllRoomQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllRoomQuery, Result<List<RoomResponseDto>>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<List<RoomResponseDto>>> Handle(GetAllRoomQuery request, CancellationToken cancellationToken)
    {
        List<RoomResponseDto> rooms = _context.Rooms.Where(r => r.IsActive).Select(r => r.toDto()).ToList();

        return Result<List<RoomResponseDto>>.Success(rooms);
    }
}
