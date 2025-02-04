namespace BillingSystem.Api.Handlers.Excpetions;

public class BillingItemCreationFailException(string message) : Exception(message)
{
}
