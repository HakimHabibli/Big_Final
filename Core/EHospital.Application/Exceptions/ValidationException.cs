
namespace EHospital.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string>? ValidationErrors { get; }

    public ValidationException(IEnumerable<ValidationFailure> failures)
    {
        ValidationErrors = failures.Select(f => f.ErrorMessage).ToList();
    }
    public ValidationException(string message) : base(message) { }
    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
