using BillingSystem.Application.Invoice.Commands;
using Wolverine;

namespace BillingSystem.Infrastructure.Consumers.HotelStay;

public class CreateInvoiceAfterCheckOutEventHandler(IMessageBus _sender)
{
    public async Task Handle(/*not mine event @event*/ )
    {
        var command = new CreateInvoiceCommand(new()
        {
            // Data
        }
        );

        await _sender.InvokeAsync(command);
    }
}
