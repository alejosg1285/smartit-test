using Application.Core;
using MediatR;

namespace Application.Commands.Room.Create;

public class CreateRoomCommand : IRequest<Result<Unit>>
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Capacity { get; set; }

    public string? TypeRoom { get; set; }

    public decimal Price { get; set; }

    public decimal Taxes { get; set; }

    public string? Location { get; set; }

    public int HotelId { get; set; }
}
