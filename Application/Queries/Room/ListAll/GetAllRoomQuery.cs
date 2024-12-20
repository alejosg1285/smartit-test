using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Room.ListAll;

public class GetAllRoomQuery : IRequest<Result<List<RoomResponseDto>>>
{
}
