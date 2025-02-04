using BillingSystem.Api.Handlers.Excpetions;
using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Shared.Models.Invoice;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace BillingSystem.Api.Handlers;

public class GuestCheckedOutHandler(IMediator mediator)
{
    private readonly IMediator mediator = mediator;

    public async Task Handle(GuestCheckedOutMessage guestCheckedOutMessage)
    {
        var createInvoiceModel = new InvoiceCreateModel() { CustomerId = guestCheckedOutMessage.GlobalGuestId };

        var result = await Result.Create(createInvoiceModel.CustomerId, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreateInvoiceCommand(createInvoiceModel))
            .Bind(command => mediator.Send(command));

        if (result.IsFailure)
        {
            throw new InvoiceCreationFailException(result.Error);
        }
    }
}
