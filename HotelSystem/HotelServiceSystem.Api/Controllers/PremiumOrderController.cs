using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.PremiumOrder.Commands.CreatePremiumOrder;
using HotelServiceSystem.Contracts.Models.PremiumOrderModels;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public class PremiumOrderController(IMediator mediator) : ApiController(mediator)
{
    [HttpPost(ApiRoutes.PremiumServiceOrder.CreateOrder)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize]
    public async Task<IActionResult> CreateOrder(CreatePremiumOrderModel createPremiumOrderModel) =>
    await Result.Create(createPremiumOrderModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new CreatePremiumOrderCommand(createPremiumOrderModel))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);
}
