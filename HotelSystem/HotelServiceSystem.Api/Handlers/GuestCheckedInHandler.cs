using HotelServiceSystem.Api.Handlers.Exceptions;
using HotelServiceSystem.Application.Guest.Commands.CreateGuest;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using SharedKernel.Messages;

namespace HotelServiceSystem.Api.Handlers
{
    public class GuestCheckedInHandler(IMediator mediator)
    {
        private readonly IMediator mediator = mediator;

        public async Task Handle(GuestCheckedInMessage guestCheckedInMessage)
        {
            var guestCheckedInCommandModel = new CreateGuestModel
            {
                GuestFirstName = guestCheckedInMessage.GuestFirstName,
                GuestLastName = guestCheckedInMessage.GuestLastName,
                GuestRoom = guestCheckedInMessage.GuestRoomNumber,
                GlobalGuestId = guestCheckedInMessage.GlobalGuestId,
                Email = guestCheckedInMessage.GuestEmail,
            };
            var result = await Result.Create(guestCheckedInMessage, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateGuestCommand(guestCheckedInCommandModel))
                .Bind(command => mediator.Send(command));

            if (result.IsFailure)
            {
                throw new GuestCheckedInFailedException(result.Error);
            }
        }
    }
}
