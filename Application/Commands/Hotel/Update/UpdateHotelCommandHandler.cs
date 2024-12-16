using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands.Hotel.Update;

public class UpdateHotelCommandHandler(ApplicationDbContext context) : IRequestHandler<UpdateHotelCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(UpdateHotelCommand request, CancellationToken cancellationToken)
    {
        Domain.Hotel hotelDb = await _context.Hotels.FindAsync(request.Id);
        if (hotelDb is null)
        {
            return null;
        }

        hotelDb.Name = request.Name;
        hotelDb.Description = request.Description;
        hotelDb.Address = request.Address;
        hotelDb.City = request.City;

        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to update the hotel");

        return Result<Unit>.Success(Unit.Value);
    }
}
