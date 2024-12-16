using Application.Core;
using Application.Models.Dto;
using MediatR;
using Persistence;

namespace Application.Queries.Book;

public class GetAvailabilityQueryHandler(ApplicationDbContext context) : IRequestHandler<GetAvailabilityQuery, Result<List<AvailableResponseDto>>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<List<AvailableResponseDto>>> Handle(GetAvailabilityQuery request, CancellationToken cancellationToken)
    {
        DateTime startFilter = request.StartSearch;
        DateTime endFilter = request.EndSearch;

        IQueryable<Domain.HotelRoom> query = _context.HotelRoom
            .Where(hr => hr.Room.Capacity >= request.Capacity && hr.Room.IsActive)
            .Where(hr => hr.Hotel.City!.ToLower().Equals(request.City!.ToLower()) && hr.Hotel.IsActive)
            .Where(hr => !_context.Books.Any(book =>
                book.HotelRoomId == hr.Id &&
                (
                    (book.StartBook <= endFilter && book.EndBook >= startFilter)
                )
            )
        )
            .Distinct()
            .AsQueryable();
        List<AvailableResponseDto> list = query
            .Select(q => new AvailableResponseDto(q.Id, q.Hotel.Name!, q.Hotel.Address!, q.Room.Name!, q.Room.Description!, q.Room.Location!, q.Room.Price, q.Room.Taxes)).ToList();

        return Result<List<AvailableResponseDto>>.Success(list);
    }
}
