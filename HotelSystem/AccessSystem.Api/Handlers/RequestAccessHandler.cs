using AccessSystem.Api.Handlers.Exceptions;
using AccessSystem.Application.AccessRequest.Commands;
using AccessSystem.Contracts.Models.AccessRequest;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;
using SharedKernel.Messages.AccessSystem;

namespace AccessSystem.Api.Handlers;

public class RequestAccessHandler(IMediator mediator)
{
    public async Task Handle(AccessRequestedMessage accessRequestedMessage)
    {
        var accessRequestCommandModel = new RequestAccessModel
        {
            AccessCardId = accessRequestedMessage.AccessCardId,
            ClaimId = accessRequestedMessage.ClaimId
        };

        var result = await Result.Create(accessRequestedMessage, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new AccessRequestCommand(accessRequestCommandModel))
            .Bind(command => mediator.Send(command));

        if (result.IsFailure)
        {
            throw new AccessRequestFailedException(result.Error);
        }

    }
}