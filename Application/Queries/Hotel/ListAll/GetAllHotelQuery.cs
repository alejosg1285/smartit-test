using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Hotel.ListAll;

public class GetAllHotelQuery : IRequest<Result<List<HotelResponseDto>>>
{
}
