using Application.Commands.Hotel.Create;
using FluentValidation;

namespace Application.Validations;

public class CreateHotelCommandValidator : AbstractValidator<CreateHotelCommand>
{
    public CreateHotelCommandValidator()
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
