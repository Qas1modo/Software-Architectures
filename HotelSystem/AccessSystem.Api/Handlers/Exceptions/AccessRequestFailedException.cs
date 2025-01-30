namespace AccessSystem.Api.Handlers.Exceptions;

public class AccessRequestFailedException(string message) : Exception(message)
{
}