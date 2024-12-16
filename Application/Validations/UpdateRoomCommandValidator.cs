using Application.Commands.Room.Update;
using FluentValidation;

namespace Application.Validations;

public class UpdateRoomCommandValidator : AbstractValidator<UpdateRoomCommand>
{
    public UpdateRoomCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name of the room is required");
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description of the room is required");
        RuleFor(p => p.Location)
            .NotEmpty()
            .WithMessage("Location of the room is required");
        RuleFor(p => p.TypeRoom)
            .NotEmpty()
            .WithMessage("Type of the room is required");
        RuleFor(p => p.Capacity)
            .GreaterThan(0)
            .WithMessage("The capacity must be greater than 0");
        RuleFor(p => p.Price)
            .GreaterThan(0)
            .WithMessage("The price must be greater than $0");
        RuleFor(p => p.Taxes)
            .GreaterThan(0)
            .WithMessage("The taxes must be greater than $0");
    }
}
