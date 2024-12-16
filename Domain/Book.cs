namespace Domain;

public class Book
{
    public int Id { get; set; }
    public DateTime StartBook { get; set; }
    public DateTime EndBook { get; set; }
    public int HotelRoomId { get; set; }
    public HotelRoom HotelRoom { get; set; } = null!;
    public Contact? Contact { get; set; }
    public ICollection<Passenger> Passengers { get; } = new List<Passenger>();
}
