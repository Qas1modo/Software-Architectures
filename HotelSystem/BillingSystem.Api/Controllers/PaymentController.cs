using BillingSystem.Api.Common;
using BillingSystem.Api.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Api.Controllers;

public class PaymentController : ApiController
{
    public PaymentController(IMediator mediator) : base(mediator)
    {  
    }

    [HttpGet(ApiRoutes.Payment.IsInvoicePaid)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> IsPaid(Guid invoiceId)
    {
        //await Maybe<GetNotCompletedCleanRoomRequestsQuery>
        //                .From(new GetNotCompletedCleanRoomRequestsQuery(invoiceId))
        //                .Bind(query => Mediator.Send(query))
        //                .Match(Ok, NotFound);

        return Ok();
    }


    [HttpPost(ApiRoutes.Payment.GetPaymentRedirectUrl)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetRedirectUrl(Guid invoiceId)
    {
        //await Maybe.Create(invoiceId.RoomNumber, DomainErrors.General.UnProcessableRequest)
        //                .Map(request => new CreateCleanRoomRequestCommand(invoiceId.RoomNumber))
        //                .Bind(command => Mediator.Send(command))
        //                .Match(Ok, BadRequest);

        return Ok();
    }
}
