using Application.Core;
using MediatR;

namespace Application.Commands.Hotel.Create;

public class CreateHotelCommand : IRequest<Result<Unit>>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }
}
