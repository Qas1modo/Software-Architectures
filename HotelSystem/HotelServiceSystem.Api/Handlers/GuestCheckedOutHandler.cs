using HotelServiceSystem.Api.Handlers.Exceptions;
using HotelServiceSystem.Application.CleanRoomRequest.Commands;
using HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using SharedKernel.Messages;

namespace HotelServiceSystem.Api.Handlers;

public class GuestCheckedOutHandler(IMediator mediator)
{
    private readonly IMediator mediator = mediator;

    public async Task Handle(GuestCheckedOutMessage guestCheckedOutMessage)
    {
        var resultDeactivateGuest = await Result.Create(guestCheckedOutMessage.GlobalGuestId, DomainErrors.General.UnProcessableRequest)
            .Map(request => new DeactivateGuestCommand(guestCheckedOutMessage.GlobalGuestId))
            .Bind(command => mediator.Send(command));
        var resultCleanRoom = await Result.Create(guestCheckedOutMessage.GuestRoomNumber, DomainErrors.General.UnProcessableRequest)
            .Map(request => new CreateCleanRoomRequestCommand(guestCheckedOutMessage.GuestRoomNumber))
            .Bind(command => mediator.Send(command));
        var result = Result.FirstFailureOrSuccess([resultDeactivateGuest, resultCleanRoom]);
        if (result.IsFailure)
        {
            throw new GuestCheckedOutFailedException(result.Error);
        }
    }
}
