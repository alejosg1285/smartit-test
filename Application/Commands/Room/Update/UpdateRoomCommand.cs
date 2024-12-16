using Application.Core;
using MediatR;

namespace Application.Commands.Room.Update;

public class UpdateRoomCommand : IRequest<Result<Unit>>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int Capacity { get; set; }

    public string? TypeRoom { get; set; }

    public decimal Price { get; set; }

    public decimal Taxes { get; set; }

    public string? Location { get; set; }

    public int HotelId { get; set; }
}
