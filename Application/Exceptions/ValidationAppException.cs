namespace Application.Exceptions;

public class ValidationAppException(IReadOnlyDictionary<string, string[]> errors) : Exception("One or more validations errors occurred")
{
    public IReadOnlyDictionary<string, string[]> Errors { get; } = errors;
}
