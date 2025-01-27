using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.RoomOrder.Commands.AcceptRoomOrder;
using HotelServiceSystem.Application.RoomOrder.Commands.CancelRoomOrder;
using HotelServiceSystem.Application.RoomOrder.Commands.CreateRoomOrder;
using HotelServiceSystem.Application.RoomOrder.Commands.DeclineRoomOrder;
using HotelServiceSystem.Application.RoomOrder.Commands.FulfillRoomOrder;
using HotelServiceSystem.Application.RoomOrder.Commands.UpdateRoomOrderCommand;
using HotelServiceSystem.Application.RoomOrder.Queries;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public class RoomServiceOrderController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost(ApiRoutes.RoomServiceOrder.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> Post(CreateRoomOrderModel roomOrderModel) =>
        await Result.Create(roomOrderModel, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateRoomOrderCommand(roomOrderModel))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);


    [HttpPatch(ApiRoutes.RoomServiceOrder.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> Update(UpdateRoomOrderModel roomOrderUpdateModel) =>
    await Result.Create(roomOrderUpdateModel, DomainErrors.General.UnProcessableRequest)
            .Map(request => new UpdateRoomOrderCommand(roomOrderUpdateModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpPut(ApiRoutes.RoomServiceOrder.Cancel)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> Cancel(CancelRoomOrderModel cancelRoomOrderModel) =>
        await Result.Create(cancelRoomOrderModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new CancelRoomOrderCommand(cancelRoomOrderModel.OrderId, cancelRoomOrderModel.GuestId))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);


    [HttpPut(ApiRoutes.RoomServiceOrder.Accept)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Employee)]
    public async Task<IActionResult> Accept(Guid orderId) =>
        await Result.Create(orderId, DomainErrors.General.UnProcessableRequest)
        .Map(request => new AcceptRoomOrderCommand(orderId))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);

    [HttpPut(ApiRoutes.RoomServiceOrder.Decline)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Employee)]
    public async Task<IActionResult> Decline(Guid orderId) =>
    await Result.Create(orderId, DomainErrors.General.UnProcessableRequest)
    .Map(request => new DeclineRoomOrderCommand(orderId))
    .Bind(command => Mediator.Send(command))
    .Match(Ok, BadRequest);

    [HttpPut(ApiRoutes.RoomServiceOrder.Fulfill)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Employee)]
    public async Task<IActionResult> Fulfill(Guid orderId) =>
        await Result.Create(orderId, DomainErrors.General.UnProcessableRequest)
        .Map(request => new FulfillRoomOrderCommand(orderId))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);

    [HttpGet(ApiRoutes.RoomServiceOrder.GetNew)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> GetNew(Guid guestId) =>
        await Maybe<GetAllNewRoomOrdersQuery>
            .From(new GetAllNewRoomOrdersQuery(guestId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpGet(ApiRoutes.RoomServiceOrder.GetCanceled)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> GetCanceled(Guid guestId) =>
        await Maybe<GetAllCanceledRoomOrdersQuery>
            .From(new GetAllCanceledRoomOrdersQuery(guestId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);


    [HttpGet(ApiRoutes.RoomServiceOrder.GetAccepted)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> GetAccepted(Guid guestId) =>
        await Maybe<GetAllAcceptedRoomOrdersQuery>
            .From(new GetAllAcceptedRoomOrdersQuery(guestId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpGet(ApiRoutes.RoomServiceOrder.GetDeclined)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> GetDeclined(Guid guestId) =>
        await Maybe<GetAllDeclinedRoomOrdersQuery>
            .From(new GetAllDeclinedRoomOrdersQuery(guestId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpGet(ApiRoutes.RoomServiceOrder.GetFulfilled)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> GetFulfilled(Guid guestId) =>
        await Maybe<GetAllFulfilledRoomOrdersQuery>
            .From(new GetAllFulfilledRoomOrdersQuery(guestId))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);
}
