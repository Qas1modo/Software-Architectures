using HotelServiceSystem.Api.Handlers.Exceptions;
using HotelServiceSystem.Application.PremiumOrder.Commands.FulfillPremiumOrder;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using SharedKernel.Messages;

namespace HotelServiceSystem.Api.Handlers;

public class RoleAssignedHandler(IMediator mediator)
{
    public async Task Handle(RoleAcceptedOnOrderMessage roleAcceptedNotification)
    {
        var result = await Result.Create(roleAcceptedNotification, DomainErrors.General.UnProcessableRequest)
            .Map(request => new FulfillPremiumOrderCommand(roleAcceptedNotification.GlobalGuestId,
                    roleAcceptedNotification.PremiumOrderId))
            .Bind(command => mediator.Send(command));
        if (result.IsFailure)
        {
            throw new RoleAssignedFailedException(result.Error);
        }
    }
}
