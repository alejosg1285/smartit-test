using Application.Core;
using Application.Models.Dto;
using MediatR;

namespace Application.Queries.Book;

public class GetAvailabilityQuery : IRequest<Result<List<AvailableResponseDto>>>
{
    /// <summary>
    /// Start date to do the search
    /// </summary>
    public DateTime StartSearch { get; set; }

    /// <summary>
    /// End date to do the search
    /// </summary>
    public DateTime EndSearch { get; set; }

    /// <summary>
    /// City where is locate the hotel to do search
    /// </summary>
    public string? City { get; set; }

    /// <summary>
    /// Number of person per room
    /// </summary>
    public int Capacity { get; set; }
}
