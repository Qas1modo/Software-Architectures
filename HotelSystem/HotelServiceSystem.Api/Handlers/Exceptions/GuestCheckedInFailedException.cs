namespace HotelServiceSystem.Api.Handlers.Exceptions;

public class GuestCheckedInFailedException(string message) : Exception(message)
{
}
