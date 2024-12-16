using Application.Exceptions;
using FluentValidation;
using MediatR;

namespace Application.Behaviours;

public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        ValidationContext<TRequest> context = new(request);
        var errorDictionary = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x is not null)
            .GroupBy(
                x => x.PropertyName.Substring(x.PropertyName.IndexOf('.') + 1),
                x => x.ErrorMessage, (propertyName, errorMessage) => new
                {
                    Key = propertyName,
                    Values = errorMessage.Distinct().ToArray()
                })
            .ToDictionary(x => x.Key, x => x.Values);

        if (errorDictionary.Any())
        {
            throw new ValidationAppException(errorDictionary);
        }

        return await next();
    }
}
