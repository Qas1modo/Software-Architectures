using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace BillingSystem.Api.Handlers;

public class PremiumOrderFulfilledHandler(IMediator mediator)
{
    public async Task Handle(PremiumOrderFulfilledMessage premiumOrderCreatedMessage)
    {
        //var updateAccessCardModel = new UpdateAccessCardFromOrderModel()
        //{
        //    HolderId = premiumOrderCreatedMessage.GlobalGuestId,
        //    RoleNameToAdd = premiumOrderCreatedMessage.RelevantRoleCodeName,
        //    PremiumOrderId = premiumOrderCreatedMessage.PremiumOrderId
        //};

        //var updateCardResult = await Result
        //    .Create(premiumOrderCreatedMessage.GlobalGuestId, DomainErrors.General.UnProcessableRequest)
        //    .Map(_ => new UpdateAccessCardFromOrderCommand(updateAccessCardModel))
        //    .Bind(command => mediator.Send(command));

        //// I didn't make the roles with capacity, so it should always pass unless error happens (like user is in the role already)
        //if (updateCardResult.IsFailure)
        //{
        //    var errorEvent = new AccessCardUpdateFailedFromOrderDomainEvent(premiumOrderCreatedMessage.GlobalGuestId, premiumOrderCreatedMessage.PremiumOrderId, updateCardResult.Error);
        //    await mediator.Publish(errorEvent);
        //    throw new PremuimOrderProcessingException(updateCardResult.Error);
        //}
        
        //var creationEvent = new AccessCardUpdatedFromOrderDomainEvent(premiumOrderCreatedMessage.GlobalGuestId, premiumOrderCreatedMessage.PremiumOrderId);
        //await mediator.Publish(creationEvent);
    }
}