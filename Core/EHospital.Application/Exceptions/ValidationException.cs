using FluentValidation.Results;
using System.Runtime.Serialization;

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
public class UserCreateFailedException : Exception
{
    public UserCreateFailedException()
    {
    }

    public UserCreateFailedException(string? message) : base(message)
    {
    }

    public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class NotFoundUserException : Exception
{
    public NotFoundUserException():base("User Name or Email is false")
    {
    }

    public NotFoundUserException(string? message) : base(message)
    {
    }

    public NotFoundUserException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
public class NotFoundException : Exception
{
    public NotFoundException(string entityName, object key)
     : base($"{entityName} with id {key} was not found.")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }

    public NotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }

}

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message)
    {
    }

    public BusinessRuleException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
public class UnAuthorizedException : Exception
{
    public UnAuthorizedException(string message) : base(message) { }
    public UnAuthorizedException(string message, Exception innerException) : base(message, innerException) { }
}
