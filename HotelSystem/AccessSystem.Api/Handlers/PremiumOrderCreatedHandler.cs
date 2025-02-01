using AccessSystem.Api.Handlers.Exceptions;
using AccessSystem.Application.AccessCard.Commands.UpdateAccessCardFromOrder;
using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Core.Errors;
using AccessSystem.Domain.Events.AccessCard;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace AccessSystem.Api.Handlers;

public class PremiumOrderCreatedHandler(IMediator mediator)
{
    public async Task Handle(PremiumOrderCreatedMessage premiumOrderCreatedMessage)
    {
        var updateAccessCardModel = new UpdateAccessCardFromOrderModel()
        {
            HolderId = premiumOrderCreatedMessage.GlobalGuestId,
            RoleNameToAdd = premiumOrderCreatedMessage.RelevantRoleCodeName,
            PremiumOrderId = premiumOrderCreatedMessage.PremiumOrderId
        };

        var updateCardResult = await Result
            .Create(premiumOrderCreatedMessage.GlobalGuestId, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new UpdateAccessCardFromOrderCommand(updateAccessCardModel))
            .Bind(command => mediator.Send(command));

        // I didn't make the roles with capacity, so it should always pass unless error happens (like user is in the role already)
        if (updateCardResult.IsFailure)
        {
            var errorEvent = new AccessCardUpdateFailedFromOrderDomainEvent(premiumOrderCreatedMessage.GlobalGuestId, premiumOrderCreatedMessage.PremiumOrderId, updateCardResult.Error);
            await mediator.Publish(errorEvent);
            throw new PremuimOrderProcessingException(updateCardResult.Error);
        }
        
        var creationEvent = new AccessCardUpdatedFromOrderDomainEvent(premiumOrderCreatedMessage.GlobalGuestId, premiumOrderCreatedMessage.PremiumOrderId);
        await mediator.Publish(creationEvent);
    }
}