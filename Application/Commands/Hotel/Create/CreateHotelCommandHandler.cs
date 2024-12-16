using Application.Core;
using MediatR;
using Persistence;

namespace Application.Commands.Hotel.Create;

public class CreateHotelCommandHandler(ApplicationDbContext context) : IRequestHandler<CreateHotelCommand, Result<Unit>>
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Result<Unit>> Handle(CreateHotelCommand request, CancellationToken cancellationToken)
    {
        Domain.Hotel hotel = new Domain.Hotel
        {
            Name = request.Name,
            Description = request.Description,
            Address = request.Address,
            City = request.City,
            IsActive = true
        };
        _context.Hotels.Add(hotel);
        var result = await _context.SaveChangesAsync() > 0;

        if (!result) return Result<Unit>.Failure("Failed to create the hotel");

        return Result<Unit>.Success(Unit.Value);
    }
}
