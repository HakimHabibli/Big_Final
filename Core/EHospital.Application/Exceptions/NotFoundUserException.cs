
namespace EHospital.Application.Exceptions;

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
