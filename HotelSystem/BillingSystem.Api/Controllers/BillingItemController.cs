using BillingSystem.Api.Common;
using BillingSystem.Api.Exceptions;
using BillingSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Api.Controllers;

public class BillingItemController : ApiController
{
    public BillingItemController(IMediator mediator) : base(mediator)
    {
        [HttpGet(ApiRoutes.BillingItems.GetBillingItems)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get( customerBillingItems) =>
            await Maybe<GetNotCompletedCleanRoomRequestsQuery>
                .From(new GetNotCompletedCleanRoomRequestsQuery(customerBillingItems))
                .Bind(query => Mediator.Send(query))
                .Match(Ok, NotFound);

        [HttpPost(ApiRoutes.BillingItems.CreateBillingItem)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateCleanRoomModel createBillingItem) =>
            await Result.Create(createBillingItem.RoomNumber, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateCleanRoomRequestCommand(createBillingItem.RoomNumber))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);

        [HttpPost(ApiRoutes.BillingItems.UpdateBillingItem)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(CreateCleanRoomModel updateBillingItem) =>
            await Result.Create(updateBillingItem.RoomNumber, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateCleanRoomRequestCommand(updateBillingItem.RoomNumber))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);

        [HttpPut(ApiRoutes.BillingItems.DeleteBillingItem)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid billingItemId) =>
            await Result.Create(billingItemId, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CleanRoomRequestCompletedCommand(billingItemId))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);
    }
}
