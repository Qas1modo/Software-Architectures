using BillingSystem.Api.Common;
using BillingSystem.Api.Exceptions;
using BillingSystem.Application.Invoice.Commands;
using BillingSystem.Application.Invoice.Queries;
using BillingSystem.Domain.Core.Errors;
using BillingSystem.Shared.Models.Invoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Api.Controllers;

public class InvoiceController : ApiController
{
    public InvoiceController(IMediator mediator) : base(mediator)
    { 
    }

    [HttpGet(ApiRoutes.Invoice.GetInvoice)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid invoiceId) =>
            await Maybe<GetInvoiceQuery>
                .From(new GetInvoiceQuery(invoiceId))
                .Bind(query => Mediator.Send(query))
                .Match(Ok, NotFound);

    [HttpPost(ApiRoutes.Invoice.CreateInvoice)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(InvoiceCreateModel createInvoice) =>
        await Result.Create(createInvoice, DomainErrors.General.UnProcessableRequest)
            .Map(request => new CreateInvoiceCommand(createInvoice))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpPut(ApiRoutes.Invoice.UpdateInvoice)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(InvoiceUpdateModel updateInvoice) =>
        await Result.Create(updateInvoice, DomainErrors.General.UnProcessableRequest)
            .Map(request => new UpdateInvoiceCommand(updateInvoice))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);

    [HttpDelete(ApiRoutes.Invoice.DeleteInvoice)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(Guid invoiceId) =>
        await Result.Create(invoiceId, DomainErrors.General.UnProcessableRequest)
            .Map(request => new DeleteInvoiceCommand(invoiceId))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}
