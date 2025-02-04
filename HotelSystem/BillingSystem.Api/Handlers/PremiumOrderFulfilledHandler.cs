using BillingSystem.Api.Handlers.Excpetions;
using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Shared.Models.BillingItem;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace BillingSystem.Api.Handlers;

public class PremiumOrderFulfilledHandler(IMediator mediator)
{
    public async Task Handle(PremiumOrderFulfilledMessage premiumOrderCreatedMessage)
    {
        var createBillingItemModel = new BillingItemCreateModel() { CustomerId = premiumOrderCreatedMessage.GlobalGuestId, ItemId = premiumOrderCreatedMessage.PremiumOrderId, UnitPrice = premiumOrderCreatedMessage.Price, Quantity = 1 };

        var result = await Result.Create(createBillingItemModel.CustomerId, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreateBillingItemCommand(createBillingItemModel))
            .Bind(command => mediator.Send(command));

        if (result.IsFailure)
        {
            throw new BillingItemCreationFailException(result.Error);
        }
    }
}