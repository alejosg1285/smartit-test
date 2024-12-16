using Application.Core;
using MediatR;

namespace Application.Commands.Hotel.Toggle;

public class ToggleHotelCommand : IRequest<Result<Unit>>
{
    public int Id { get; set; }
}
