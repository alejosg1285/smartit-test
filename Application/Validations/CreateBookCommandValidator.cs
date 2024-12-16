using Application.Commands.Book;
using FluentValidation;

namespace Application.Validations;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.BookRequest!.StartBook).NotEmpty().Must(startBook => !startBook.Equals(default(DateTime)));
        RuleFor(x => x.BookRequest!.EndBook).NotEmpty().Must(endBook => !endBook.Equals(default(DateTime)));

        RuleForEach(x => x.BookRequest!.Passengers).ChildRules(passenger =>
        {
            passenger.RuleFor(p => p.Name).NotEmpty();
            passenger.RuleFor(p => p.LastName).NotEmpty();
            passenger.RuleFor(p => p.IdentificationType).NotEmpty();
            passenger.RuleFor(p => p.IdentificationNumber).NotEmpty();
            passenger.RuleFor(p => p.Genre).NotEmpty().IsInEnum();
            passenger.RuleFor(p => p.Email).NotEmpty().EmailAddress();
            passenger.RuleFor(p => p.PhoneNumber).Length(10).NotEmpty();
        });

        RuleFor(x => x.BookRequest!.HotelRoomId).NotEmpty();
        RuleFor(x => x.BookRequest!.Contact!.Name).NotEmpty();
        RuleFor(x => x.BookRequest!.Contact!.LastName).NotEmpty();
        RuleFor(x => x.BookRequest!.Contact!.PhoneNumber).Length(10).NotEmpty();
    }
}
