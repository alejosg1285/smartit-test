using Application.Core;
using Application.Models.Dto;
using MediatR;
using Persistence;

namespace Application.Queries.Hotel.ListAll;

public class GetAllHotelQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAllHotelQuery, Result<List<HotelResponseDto>>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<List<HotelResponseDto>>> Handle(GetAllHotelQuery request, CancellationToken cancellationToken)
    {
        List<Domain.Hotel> hotels = _context.Hotels.ToList();
        List<HotelResponseDto> list = hotels.Where(h => h.IsActive).Select(h => h.toDto()).ToList();

        return Result<List<HotelResponseDto>>.Success(list);
    }
}
