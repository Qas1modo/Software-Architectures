using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.AccessClaim.Commands.CreateAccessClaim;
using AccessSystem.Application.AccessClaim.Commands.DeleteAccessClaim;
using AccessSystem.Application.AccessClaim.Commands.UpdateAccessClaim;
using AccessSystem.Application.AccessClaim.Queries.GetAccessClaim;
using AccessSystem.Contracts.Models.AccessClaim;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Api.Controllers;

public class AccessClaimController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.AccessClaim.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(GetAccessClaimModel getAccessClaimModel) =>
        await Maybe<GetAccessClaimQuery>
            .From(new GetAccessClaimQuery(getAccessClaimModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);
    
    [HttpPost(ApiRoutes.AccessClaim.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateAccessClaimModel createAccessClaimModel) =>
        await Result.Create(createAccessClaimModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreateAccessClaimCommand(createAccessClaimModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    
    [HttpPatch(ApiRoutes.AccessClaim.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateAccessClaimModel updateAccessClaimModel) =>
        await Result.Create(updateAccessClaimModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new UpdateAccessClaimCommand(updateAccessClaimModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    [HttpDelete(ApiRoutes.AccessClaim.Delete)]
    [ProducesResponseType(~StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(DeleteAccessClaimModel deleteAccessClaimModel) =>
        await Result.Create(deleteAccessClaimModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new DeleteAccessClaimCommand(deleteAccessClaimModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}