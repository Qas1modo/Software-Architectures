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
    public IActionResult IsPaid(Guid invoiceId)
    {
        return Ok(false);
    }


    [HttpGet(ApiRoutes.Payment.GetPaymentRedirectUrl)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public IActionResult GetRedirectUrl(Guid invoiceId)
    {
        return Ok("https://www.google.com/");
    }
}
