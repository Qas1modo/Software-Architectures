using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.RoomService.Commands.CreateRoomService;
using HotelServiceSystem.Application.RoomService.Commands.DeleteRoomService;
using HotelServiceSystem.Application.RoomService.Commands.UpdateRoomService;
using HotelServiceSystem.Application.RoomService.Queries;
using HotelServiceSystem.Contracts.Models.RoomServiceModels;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public class RoomServiceController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.RoomService.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(GetRoomServicesModel getRoomServicesModel) =>
        await Maybe<RoomServiceGetAllPagedQuery>
            .From(new RoomServiceGetAllPagedQuery(getRoomServicesModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.RoomService.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Post(CreateRoomServiceModel createRoomServicesModel) =>
    await Result.Create(createRoomServicesModel, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateRoomServiceCommand(createRoomServicesModel))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);

    [HttpPatch(ApiRoutes.RoomService.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Update(UpdateRoomServiceModel updateRoomServiceModel) =>
    await Result.Create(updateRoomServiceModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new UpdateRoomServiceCommand(updateRoomServiceModel))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);

    [HttpDelete(ApiRoutes.RoomService.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Delete(DeleteRoomServiceModel deleteRoomServiceModel) =>
        await Result.Create(deleteRoomServiceModel, DomainErrors.General.UnProcessableRequest)
            .Map(request => new DeleteRoomServiceCommand(deleteRoomServiceModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}
