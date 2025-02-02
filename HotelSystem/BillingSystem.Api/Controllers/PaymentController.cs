using BillingSystem.Api.Common;
using BillingSystem.Api.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Api.Controllers;

public class PaymentController : ApiController
{
    public PaymentController(IMediator mediator) : base(mediator)
    {
        [HttpGet(ApiRoutes.Payment.IsInvoicePaid)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> IsPaid(GetAllNotCompletedCleanRequestsPagedModel invoiceId) =>
            await Maybe<GetNotCompletedCleanRoomRequestsQuery>
                .From(new GetNotCompletedCleanRoomRequestsQuery(invoiceId))
                .Bind(query => Mediator.Send(query))
                .Match(Ok, NotFound);

        [HttpPost(ApiRoutes.Payment.GetPaymentRedirectUrl)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetRedirectUrl(CreateCleanRoomModel invoiceId) =>
            await Maybe.Create(invoiceId.RoomNumber, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateCleanRoomRequestCommand(invoiceId.RoomNumber))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);
    }
}
