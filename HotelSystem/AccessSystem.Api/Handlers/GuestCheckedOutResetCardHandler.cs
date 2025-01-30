using AccessSystem.Api.Handlers.Exceptions;
using AccessSystem.Application.AccessCard.Commands.ResetAccessCard;
using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace AccessSystem.Api.Handlers;

public class GuestCheckedOutResetCardHandler(IMediator mediator)
{
    private readonly IMediator mediator = mediator;

    public async Task Handle(GuestCheckedOutMessage guestCheckedOutMessage)
    {
        var resetCardModel = new ResetAccessCardModel
        {
            HolderId = guestCheckedOutMessage.GlobalGuestId
        };
        
        var resetCardResult = await Result.Create(guestCheckedOutMessage.GlobalGuestId, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new ResetAccessCardCommand(resetCardModel))
            .Bind(command => mediator.Send(command));

        if (resetCardResult.IsFailure)
        {
            throw new CardResetOnGuestCheckoutException(resetCardResult.Error);
        }
    }
}