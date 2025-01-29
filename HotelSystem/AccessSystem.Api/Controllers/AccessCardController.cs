using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.AccessCard.Commands.CreateAccessCard;
using AccessSystem.Application.AccessCard.Commands.DeleteAccessCard;
using AccessSystem.Application.AccessCard.Commands.ResetAccessCard;
using AccessSystem.Application.AccessCard.Commands.UpdateAccessCard;
using AccessSystem.Application.AccessCard.Queries.GetCard;
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
        await Maybe<GetCardQuery>
            .From(new GetCardQuery(getAccessCardModel))
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
    
    [HttpPost(ApiRoutes.AccessCard.ResetCard)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ResetCard(ResetAccessCardModel resetAccessCardModel) =>
        await Result.Create(resetAccessCardModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new ResetAccessCardCommand(resetAccessCardModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}