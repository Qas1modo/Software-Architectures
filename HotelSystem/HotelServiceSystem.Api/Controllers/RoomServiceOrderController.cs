using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.RoomOrder.Commands.CreateRoomOrder;
using HotelServiceSystem.Contracts.Models.RoomOrder;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public class RoomServiceOrderController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.RoomServiceOrder.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateRoomOrderModel roomOrderModel) =>
        await Result.Create(roomOrderModel, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateRoomOrderCommand(roomOrderModel))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);
}
