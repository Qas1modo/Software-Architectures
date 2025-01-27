using HotelServiceSystem.Api.Handlers.Exceptions;
using HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using SharedKernel.Messages;

namespace HotelServiceSystem.Api.Handlers
{
    public class RoleDeniedHandler(IMediator mediator) 
    {
        public async Task Handle(RoleDeniedOnOrderMessage roleDeniedNotification)
        {
            var result = await Result.Create(roleDeniedNotification, DomainErrors.General.UnProcessableRequest)
                .Map(request => new DeclinePremiumOrderCommand(roleDeniedNotification.GlobalGuestId,
                        roleDeniedNotification.PremiumOrderId, roleDeniedNotification.Reason))
                .Bind(command => mediator.Send(command));
            if (result.IsFailure)
            {
                throw new RoleDeniedFailedException(result.Error);
            }
        }
    }
}
