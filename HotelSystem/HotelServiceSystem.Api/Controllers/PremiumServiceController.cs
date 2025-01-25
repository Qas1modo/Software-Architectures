using HotelServiceSystem.Api.Contracts;
using HotelServiceSystem.Api.Infrastructure;
using HotelServiceSystem.Application.PremiumService.Commands.CreatePremiumService;
using HotelServiceSystem.Application.PremiumService.Commands.DeletePremiumService;
using HotelServiceSystem.Application.PremiumService.Commands.UpdatePremiumService;
using HotelServiceSystem.Application.PremiumService.Queries;
using HotelServiceSystem.Contracts.Models.PremiumServiceModels;
using HotelServiceSystem.Domain.Core.Errors;
using HotelServiceSystem.Domain.Core.Primitives.Maybe;
using HotelServiceSystem.Domain.Core.Primitives.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelServiceSystem.Api.Controllers;

public class PremiumServiceController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.PremiumService.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(GetPremiumServicesModel premiumServicesModel) =>
        await Maybe<PremiumServiceGetAllPagedQuery>
            .From(new PremiumServiceGetAllPagedQuery(premiumServicesModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.PremiumService.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Post(CreatePremiumServiceModel createPremiumServicesModel) =>
        await Result.Create(createPremiumServicesModel, DomainErrors.General.UnProcessableRequest)
            .Map(request => new CreatePremiumServiceCommand(createPremiumServicesModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpPatch(ApiRoutes.PremiumService.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Update(UpdatePremiumServiceModel updatePremiumServiceModel) =>
        await Result.Create(updatePremiumServiceModel, DomainErrors.General.UnProcessableRequest)
    .Map(request => new UpdatePremiumServiceCommand(updatePremiumServiceModel))
    .Bind(command => Mediator.Send(command))
    .Match(Ok, BadRequest);

    [HttpDelete(ApiRoutes.PremiumService.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    //[Authorize(Role = Admin)]
    public async Task<IActionResult> Delete(DeletePremiumServiceModel deletePremiumServiceModel) =>
    await Result.Create(deletePremiumServiceModel, DomainErrors.General.UnProcessableRequest)
        .Map(request => new DeletePremiumServiceCommand(deletePremiumServiceModel))
        .Bind(command => Mediator.Send(command))
        .Match(Ok, BadRequest);
}
