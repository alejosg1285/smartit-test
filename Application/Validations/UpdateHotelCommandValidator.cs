using Application.Commands.Hotel.Update;
using FluentValidation;

namespace Application.Validations;

public class UpdateHotelCommandValidator : AbstractValidator<UpdateHotelCommand>
{
    public UpdateHotelCommandValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Name of the hotel is required");
        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Description of the hotel is required");
        RuleFor(p => p.Address)
            .NotEmpty()
            .WithMessage("Address of the hotel is required");
        RuleFor(p => p.City)
            .NotEmpty()
            .WithMessage("City of the hotel is required");
    }
}
