using Application.Core;
using Application.Models.Dto;
using MediatR;
using Persistence;

namespace Application.Queries.Hotel.Detail;

public class DetailHotelQueryHandler(ApplicationDbContext context) : IRequestHandler<DetailHotelQuery, Result<HotelDetailResponseDto>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<HotelDetailResponseDto>> Handle(DetailHotelQuery request, CancellationToken cancellationToken)
    {
        HotelDetailResponseDto? hotel = _context.Hotels
            .Where(h => h.Id == request.HotelId)
            .Select(h => new HotelDetailResponseDto(
                h.Id,
                h.Name,
                h.Description,
                h.Address,
                h.City,
                _context.HotelRoom
                    .Where(hr => hr.HotelId == request.HotelId)
                    .Select(r => r.Room.toDto())
                    .ToList()
            ))
            .FirstOrDefault();
        if (hotel is null)
        {
            return null;
        }

        return Result<HotelDetailResponseDto>.Success(hotel);
    }
}
