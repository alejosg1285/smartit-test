using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands.Hotel.Toggle;

public class ToggleHotelCommandHandler(ApplicationDbContext context) : IRequestHandler<ToggleHotelCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(ToggleHotelCommand request, CancellationToken cancellationToken)
    {
        Domain.Hotel hotelDb = await _context.Hotels.FindAsync(request.Id);
        if (hotelDb is null)
        {
            return null;
        }

        hotelDb.IsActive = !hotelDb.IsActive;
        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to active/inactive the hotel");

        return Result<Unit>.Success(Unit.Value);
    }
}
