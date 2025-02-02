using BillingSystem.Api.Common;
using BillingSystem.Api.Exceptions;
using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Shared.Models.BillingItem;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Api.Controllers;

public class BillingItemController : ApiController
{
    public BillingItemController(IMediator mediator) : base(mediator)
    {
    }

    [HttpGet(ApiRoutes.BillingItems.GetBillingItems)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid billingItemId) =>
            await Maybe<GetBillingItemsByCustomerQuery>
                .From(new GetBillingItemsByCustomerQuery(billingItemId))
                .Bind(query => Mediator.Send(query))
                .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.BillingItems.CreateBillingItem)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(BillingItemCreateModel createBillingItem) =>
        await Result.Create(createBillingItem, DomainErrors.General.UnProcessableRequest)
            .Map(request => new CreateBillingItemCommand(createBillingItem))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpPut(ApiRoutes.BillingItems.UpdateBillingItem)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(BillinItemUpdateModel updateBillingItem) =>
        await Result.Create(updateBillingItem, DomainErrors.General.UnProcessableRequest)
            .Map(request => new UpdateBillingItemCommand(updateBillingItem))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpDelete(ApiRoutes.BillingItems.DeleteBillingItem)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid billingItemId) =>
        await Result.Create(billingItemId, DomainErrors.General.UnProcessableRequest)
            .Map(request => new DeleteBillingItemCommand(billingItemId))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}
