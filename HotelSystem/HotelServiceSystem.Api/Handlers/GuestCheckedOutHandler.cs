using HotelServiceSystem.Api.Handlers.Exceptions;
using HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using SharedKernel.Messages;

namespace HotelServiceSystem.Api.Handlers
{
    public class GuestCheckedOutHandler(IMediator mediator)
    {
        private readonly IMediator mediator = mediator;

        public async Task Handle(GuestCheckedOutMessage guestCheckedOutMessage)
        {
            var result = await Result.Create(guestCheckedOutMessage, DomainErrors.General.UnProcessableRequest)
                .Map(request => new DeactivateGuestCommand(guestCheckedOutMessage.GlobalGuestId))
                .Bind(command => mediator.Send(command));
            if (result.IsFailure)
            {
                throw new GuestCheckedInFailedException(result.Error);
            }
        }
    }
}
