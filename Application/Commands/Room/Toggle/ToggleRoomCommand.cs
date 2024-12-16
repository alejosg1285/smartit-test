using Application.Core;
using MediatR;

namespace Application.Commands.Room.Toggle;

public class ToggleRoomCommand : IRequest<Result<Unit>>
{
    public int Id { get; set; }
}
