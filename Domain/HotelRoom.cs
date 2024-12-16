using System.ComponentModel.DataAnnotations;

namespace Domain;

public class HotelRoom
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Hotel for the room is required")]
    public int HotelId { get; set; }

    public Hotel Hotel { get; set; } = null!;

    [Required(ErrorMessage = "Room for the hotel is required")]
    public int RoomId { get; set; }

    public Room Room { get; set; } = null!;
}
