using Application.Queries.Book.Detail;
using FluentValidation;

namespace Application.Validations;

public class DetailBookQueryValidator : AbstractValidator<DetailBookQuery>
{
    public DetailBookQueryValidator()
    {
        RuleFor(p => p.BookId)
            .GreaterThan(0)
            .WithMessage("The book id is required");
    }
}
