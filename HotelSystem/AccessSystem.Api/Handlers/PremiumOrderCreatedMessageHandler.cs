using AccessSystem.Api.Handlers.Exceptions;
using AccessSystem.Application.AccessCard.Commands.UpdateAccessCard;
using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace AccessSystem.Api.Handlers;

public class PremiumOrderCreatedMessageHandler(IMediator mediator)
{
    private readonly IMediator mediator = mediator;

    public async Task Handle(PremiumOrderCreatedMessage premiumOrderCreatedMessage)
    {
        var updateAccessCardModel = new UpdateAccessCardModel
        {
            HolderId = premiumOrderCreatedMessage.GlobalGuestId,
            RoleNamesToAdd = [premiumOrderCreatedMessage.RelevantRoleCodeName]
        };

        var updateCardResult = await Result
            .Create(premiumOrderCreatedMessage.GlobalGuestId, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new UpdateAccessCardCommand(updateAccessCardModel))
            .Bind(command => mediator.Send(command));


        // I didn't make the roles with capacity, so it should always pass unless error happens
        if (updateCardResult.IsFailure)
        {
            await mediator.Publish(new RoleDeniedOnOrderMessage(
                premiumOrderCreatedMessage.GlobalGuestId,
                premiumOrderCreatedMessage.PremiumOrderId,
                updateCardResult.Error
            ));

            return;
        }

        await mediator.Publish(new RoleAcceptedOnOrderMessage(
            premiumOrderCreatedMessage.GlobalGuestId,
            premiumOrderCreatedMessage.PremiumOrderId
        ));
    }
}