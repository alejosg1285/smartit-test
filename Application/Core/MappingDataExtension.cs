using Application.Models;
using Application.Models.Dto;
using Azure.Core;
using Domain;

namespace Application.Core;

public static class MappingDataExtension
{
    public static Book fromRequest(this BookRequest request)
    {
        return new Book
        {
            StartBook = request.StartBook,
            EndBook = request.EndBook,
            HotelRoomId = request.HotelRoomId,
        };
    }

    public static Contact fromDto(this ContactRequestDto dto)
    {
        return new Contact
        {
            Name = dto.Name,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
        };
    }

    public static Passenger fromDto(this PassengerRequestDto dto)
    {
        return new Passenger
        {
            IdentificationNumber = dto.IdentificationNumber,
            Name = dto.Name,
            LastName = dto.LastName,
            Genre = dto.Genre,
            Email = dto.Email,
            PhoneNumber = dto.PhoneNumber,
            IdentificationType = dto.IdentificationType,
        };
    }

    public static GetAllBookDto toDto(this Book book)
    {
        return new GetAllBookDto(book.Id, book.StartBook, book.EndBook, book.HotelRoom.Hotel.Name, book.HotelRoom.Room.Name);
    }

    public static HotelResponseDto toDto(this Hotel hotel)
    {
        return new HotelResponseDto(hotel.Name, hotel.Description, hotel.Address, hotel.City);
    }

    public static RoomResponseDto toDto(this Room room)
    {
        return new RoomResponseDto(room.Name, room.Description, room.Capacity, room.TypeRoom, room.Price, room.Taxes, room.Location);
    }

    public static ContactResponseDto toDto(this Contact contact)
    {
        return new ContactResponseDto(contact.Name, contact.LastName, contact.PhoneNumber);
    }

    public static PassengerResponseDto toDto(this Passenger passenger)
    {
        return new PassengerResponseDto(
            passenger.Name,
            passenger.LastName,
            passenger.Genre,
            passenger.IdentificationType,
            passenger.IdentificationNumber,
            passenger.Email,
            passenger.PhoneNumber
        );
    }

    public static BookDetailResponseDto toDetailDto(this Book book)
    {
        HotelResponseDto hotel = book.HotelRoom.Hotel.toDto();
        RoomResponseDto room = book.HotelRoom.Room.toDto();
        ContactResponseDto contact = book.Contact.toDto();
        List<PassengerResponseDto> passengers = book.Passengers.Select(p => p.toDto()).ToList();

        return new BookDetailResponseDto(book.StartBook, book.EndBook, hotel, room, contact, passengers);
    }
}
