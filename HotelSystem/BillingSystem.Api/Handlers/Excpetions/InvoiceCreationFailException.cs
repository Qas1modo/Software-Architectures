namespace BillingSystem.Api.Handlers.Excpetions;

public class InvoiceCreationFailException(string message) : Exception(message)
{
}
