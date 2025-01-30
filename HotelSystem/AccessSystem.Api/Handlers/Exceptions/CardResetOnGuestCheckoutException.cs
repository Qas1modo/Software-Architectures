namespace AccessSystem.Api.Handlers.Exceptions;

public class CardResetOnGuestCheckoutException(string message) : Exception(message)
{
}