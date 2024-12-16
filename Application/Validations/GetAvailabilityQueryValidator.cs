using Application.Queries.Book;
using FluentValidation;

namespace Application.Validations;

public class GetAvailabilityQueryValidator : AbstractValidator<GetAvailabilityQuery>
{
    public GetAvailabilityQueryValidator()
    {
        RuleFor(v => v.City)
            .NotEmpty()
            .WithMessage("The to search is required");

        RuleFor(v => v.Capacity)
            .GreaterThan(0)
            .WithMessage("The capacity of the room is required");
    }
}
