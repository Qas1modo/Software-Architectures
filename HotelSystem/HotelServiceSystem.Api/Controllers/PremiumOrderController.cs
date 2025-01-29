using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.PremiumOrder.Commands.CreatePremiumOrder;
using HotelServiceSystem.Application.PremiumOrder.Commands.DeclinePremiumOrder;
using HotelServiceSystem.Application.PremiumOrder.Queries;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public class PremiumOrderController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.PremiumServiceOrder.GetOrders)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    //[Authorize]
    public async Task<IActionResult> Get(GetPremiumOrdersModel getPremiumOrdersModel) =>
        await Maybe<GetOrdersForUserPagedQuery>
            .From(new GetOrdersForUserPagedQuery(getPremiumOrdersModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.PremiumServiceOrder.CreateOrder)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> Create(CreatePremiumOrderModel createPremiumOrderModel) =>
    await Result.Create(createPremiumOrderModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new CreatePremiumOrderCommand(createPremiumOrderModel))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);

    [HttpPost(ApiRoutes.PremiumServiceOrder.CancelOrder)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Decline(DeclinePremiumOrderModel declinePremiumOrder) =>
        await Result.Create(declinePremiumOrder, DomainErrors.General.UnProcessableRequest)
    .Map(request => new DeclinePremiumOrderCommand(declinePremiumOrder.GuestId, declinePremiumOrder.PremiumOrderId, declinePremiumOrder.Reason))
    .Bind(command => Mediator.Send(command))
    .Match(Ok, BadRequest);
}
