using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.AccessCard.Commands;
using AccessSystem.Application.AccessCard.Queries;
using AccessSystem.Contracts.Models.AccessCard;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Api.Controllers;

public sealed class AccessCardController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.AccessCard.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(GetAccessCardModel getAccessCardModel) =>
        await Maybe<AccessCardGetCardQuery>
            .From(new AccessCardGetCardQuery(getAccessCardModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);
    
    [HttpPost(ApiRoutes.AccessCard.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateAccessCardModel createAccessCardModel) =>
        await Result.Create(createAccessCardModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreateAccessCardCommand(createAccessCardModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpPatch(ApiRoutes.AccessCard.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateAccessCardModel updateAccessCardModel) =>
        await Result.Create(updateAccessCardModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new UpdateAccessCardCommand(updateAccessCardModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    [HttpDelete(ApiRoutes.AccessCard.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(DeleteAccessCardModel deleteAccessCardModel) =>
        await Result.Create(deleteAccessCardModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new DeleteAccessCardCommand(deleteAccessCardModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}