using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain;

public class Hotel
{
    public int Id { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "Name of the hotel is required")]
    public string? Name { get; set; }

    [MaxLength(250)]
    [Required(ErrorMessage = "Description of the hotel is required")]
    public string? Description { get; set; }

    [MaxLength(70)]
    [Required(ErrorMessage = "Address of the hotel is required")]
    public string? Address { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "City of the hotel is required")]
    public string? City { get; set; }

    [DefaultValue(true)]
    public bool IsActive { get; set; }

    public ICollection<HotelRoom> Rooms { get; } = [];
}
