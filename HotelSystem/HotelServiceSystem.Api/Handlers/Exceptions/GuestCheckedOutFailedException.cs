namespace HotelServiceSystem.Api.Handlers.Exceptions;

public class GuestCheckedOutFailedException(string message) : Exception(message)
{
}
