using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Hotel.Detail;

public class DetailHotelQuery : IRequest<Result<HotelDetailResponseDto>>
{
    public int HotelId { get; set; }
}
