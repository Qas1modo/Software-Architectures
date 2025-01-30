namespace HotelServiceSystem.Api.Handlers.Exceptions;

public class RoleDeniedFailedException(string message) : Exception(message)
{
}
