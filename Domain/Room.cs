using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain;

public class Room
{
    public int Id { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "Name of the room is required")]
    public string? Name { get; set; }

    [MaxLength(250)]
    [Required(ErrorMessage = "Description of the room is required")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Capacity of the room is required")]
    public int Capacity { get; set; }

    [MaxLength(25)]
    [Required(ErrorMessage = "Type of room is required")]
    public string? TypeRoom { get; set; }

    [Required(ErrorMessage = "The based price is required")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The taxes are required")]
    public decimal Taxes { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "Location of the room is required")]
    public string? Location { get; set; }

    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public ICollection<HotelRoom> Hotels { get; } = [];
}
