using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Book;

public class GetAvailabilityQuery : IRequest<Result<List<AvailableResponseDto>>>
{
    public DateTime StartSearch { get; set; }
    public DateTime EndSearch { get; set; }
    public string? City { get; set; }
    public int Capacity { get; set; }
}
