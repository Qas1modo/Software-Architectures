using BillingSystem.Application.BillingItem.Commands;
using Wolverine;

namespace BillingSystem.Application.Consumers.Service;

public class RoomServiceOrderFullfiledEventHandler(IMessageBus _sender)
{
    public async Task Handle(/*not mine event @event*/ )
    {
        var command = new CreateBillingItemCommand(new() 
        { 
            // Data
        }
        );

        await _sender.InvokeAsync(command);
    }
}
