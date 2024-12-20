using Application.Core;
using Application.Models.Dto;
using MediatR;
using Persistence;

namespace Application.Queries.Room.Detail;

public class DetailRoomQueryHandler(ApplicationDbContext context) : IRequestHandler<DetailRoomQuery, Result<RoomDetailResponseDto>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<RoomDetailResponseDto>> Handle(DetailRoomQuery request, CancellationToken cancellationToken)
    {
        RoomDetailResponseDto? room = _context.Rooms
            .Where(r => r.Id == request.RoomId)
            .Select(r => new RoomDetailResponseDto(
                r.Id, r.Name, r.Description, r.Capacity, r.TypeRoom, r.Price, r.Taxes, r.Location,
                _context.HotelRoom
                    .Where(hr => hr.RoomId == request.RoomId)
                    .Select(h => h.Hotel.toDto())
                    .ToList()
            ))
            .FirstOrDefault();
        if (room is null)
        {
            return null;
        }

        return Result<RoomDetailResponseDto>.Success(room);
    }
}
