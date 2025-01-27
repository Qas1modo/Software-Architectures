using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.Guest.Commands.CreateGuest;
using HotelServiceSystem.Application.Guest.Commands.DeactivateGuest;
using HotelServiceSystem.Application.Guest.Commands.DeleteGuest;
using HotelServiceSystem.Application.Guest.Commands.UpdateGuest;
using HotelServiceSystem.Application.Guest.Queries;
using HotelServiceSystem.Contracts.Models.Guest;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public sealed class GuestController(IMediator mediator) : ApiController(mediator)
{

    [HttpGet(ApiRoutes.Guest.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Get(GetAllGuestsPaged getAllGuestsPaged) =>
    await Maybe<GetAllGuestsQuery>
        .From(new GetAllGuestsQuery(getAllGuestsPaged))
        .Bind(query => Mediator.Send(query))
        .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.Guest.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Post(CreateGuestModel createGuestModel) =>
        await Result.Create(createGuestModel, DomainErrors.General.UnProcessableRequest)
            .Map(request => new CreateGuestCommand(createGuestModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpDelete(ApiRoutes.Guest.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Delete(DeleteGuestModel deleteGuestModel) =>
    await Result.Create(deleteGuestModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new DeleteGuestCommand(deleteGuestModel.GuestId))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);

    [HttpPatch(ApiRoutes.Guest.DeactivateGuest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Deactivate(Guid externalGuestId) =>
        await Result.Create(externalGuestId, DomainErrors.General.UnProcessableRequest)
    .Map(request => new DeactivateGuestCommand(externalGuestId))
    .Bind(command => Mediator.Send(command))
    .Match(Ok, BadRequest);

    [HttpPatch(ApiRoutes.Guest.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Update(UpdateGuestModel updateGuestModel) =>
    await Result.Create(updateGuestModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new UpdateGuestCommand(updateGuestModel))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);
}
