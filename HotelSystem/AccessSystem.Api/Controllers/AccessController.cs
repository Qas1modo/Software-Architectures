using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.AccessRequest.Commands;
using AccessSystem.Contracts.Models.AccessRequest;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Api.Controllers;

public class AccessController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost(ApiRoutes.Access.RequestAccess)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RequestAccess(RequestAccessModel requestAccessModel) =>
        await Result.Create(requestAccessModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new AccessRequestCommand(requestAccessModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}