using Application.Models.Dto;

namespace Application.Models;

public class BookRequest
{
    /// <summary>
    /// Start date to the book
    /// </summary>
    public DateTime StartBook { get; set; }

    /// <summary>
    /// End date to the book
    /// </summary>
    public DateTime EndBook { get; set; }

    /// <summary>
    /// Relation hotel-room selected to the book
    /// </summary>
    public int HotelRoomId { get; set; }

    /// <inheritdoc cref="ContactRequestDto"/>
    public ContactRequestDto? Contact { get; set; }

    /// <inheritdoc cref="PassengerRequestDto"/>
    public List<PassengerRequestDto>? Passengers { get; set; }
}
