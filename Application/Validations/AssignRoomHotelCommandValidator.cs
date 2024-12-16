using Application.Commands.Hotel.AssignRoom;
using FluentValidation;

namespace Application.Validations;

public class AssignRoomHotelCommandValidator : AbstractValidator<AssignRoomHotelCommand>
{
    public AssignRoomHotelCommandValidator()
    {
        RuleFor(p => p.HotelId)
            .NotEmpty()
            .WithMessage("The hotel is required");
        RuleFor(p => p.HotelId)
            .GreaterThan(0)
            .WithMessage("The hotel is required");
        RuleFor(p => p.RoomId)
            .NotEmpty()
            .WithMessage("The room is required");
        RuleFor(p => p.RoomId)
            .GreaterThan(0)
            .WithMessage("The room is required");
    }
}
