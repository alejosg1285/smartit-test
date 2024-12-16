using Application.Models.Dto;

namespace Application.Models;

public class BookRequest
{
    public DateTime StartBook { get; set; }
    public DateTime EndBook { get; set; }
    public int HotelRoomId { get; set; }
    public ContactRequestDto? Contact { get; set; }
    public List<PassengerRequestDto>? Passengers { get; set; }
}
