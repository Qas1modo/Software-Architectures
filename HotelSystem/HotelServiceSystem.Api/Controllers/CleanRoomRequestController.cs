using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.CleanRoomRequest.Commands;
using HotelServiceSystem.Application.CleanRoomRequest.Queries;
using HotelServiceSystem.Contracts.Models.CleanRoomRequestModels;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public sealed class CleanRoomRequestController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.CleanRoomRequest.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    //[Authorize(Role = Employee)]
    public async Task<IActionResult> Get(GetAllNotCompletedCleanRequestsPagedModel notCompletedCleanRequestsPagedModel) =>
        await Maybe<GetNotCompletedCleanRoomRequestsQuery>
            .From(new GetNotCompletedCleanRoomRequestsQuery(notCompletedCleanRequestsPagedModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.CleanRoomRequest.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Post(CreateCleanRoomModel createCleanRoomRequestModel) =>
        await Result.Create(createCleanRoomRequestModel.RoomNumber, DomainErrors.General.UnProcessableRequest)
            .Map(request => new CreateCleanRoomRequestCommand(createCleanRoomRequestModel.RoomNumber))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpPut(ApiRoutes.CleanRoomRequest.Put)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Employee)]
    public async Task<IActionResult> Done(Guid cleanRoomRequestId) =>
    await Result.Create(cleanRoomRequestId, DomainErrors.General.UnProcessableRequest)
        .Map(request => new CleanRoomRequestCompletedCommand(cleanRoomRequestId))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);
}
