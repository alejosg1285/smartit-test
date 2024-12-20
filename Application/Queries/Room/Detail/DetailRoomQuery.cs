using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Room.Detail;

public class DetailRoomQuery : IRequest<Result<RoomDetailResponseDto>>
{
    public int RoomId { get; set; }
}
