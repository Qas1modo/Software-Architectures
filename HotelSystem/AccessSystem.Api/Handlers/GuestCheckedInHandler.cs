using AccessSystem.Api.Handlers.Exceptions;
using AccessSystem.Application.AccessCard.Commands.CreateAccessCard;
using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages;

namespace AccessSystem.Api.Handlers;

public class GuestCheckedInHandler(IMediator mediator)
{
    public async Task Handle(GuestCheckedInMessage guestCheckedInMessage)
    {
        var createAccessCardModel = new CreateAccessCardModel()
        {
            HolderId = guestCheckedInMessage.GlobalGuestId,
            RoleNames = ["Room" + guestCheckedInMessage.GuestRoomNumber]
        };

        var resetCardResult = await Result.Create(guestCheckedInMessage.GlobalGuestId, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreateAccessCardCommand(createAccessCardModel))
            .Bind(command => mediator.Send(command));

        if (resetCardResult.IsFailure)
        {
            throw new CardSetupOnCheckinException(resetCardResult.Error);
        }
    }
}