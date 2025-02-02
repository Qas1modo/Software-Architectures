using BillingSystem.Api.Common;
using BillingSystem.Api.Exceptions;
using BillingSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace BillingSystem.Api.Controllers;

public class InvoiceController : ApiController
{
    public InvoiceController(IMediator mediator) : base(mediator)
    {
        [HttpGet(ApiRoutes.Invoice.GetInvoice)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(GetAllNotCompletedCleanRequestsPagedModel customerInvoice) =>
            await Maybe<GetNotCompletedCleanRoomRequestsQuery>
                .From(new GetNotCompletedCleanRoomRequestsQuery(customerInvoice))
                .Bind(query => Mediator.Send(query))
                .Match(Ok, NotFound);

        [HttpPost(ApiRoutes.Invoice.CreateInvoice)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(CreateCleanRoomModel createInvoice) =>
            await Result.Create(createInvoice.RoomNumber, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateCleanRoomRequestCommand(createInvoice.RoomNumber))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);

        [HttpPost(ApiRoutes.Invoice.UpdateInvoice)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(CreateCleanRoomModel updateInvoice) =>
            await Result.Create(updateInvoice.RoomNumber, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateCleanRoomRequestCommand(updateInvoice.RoomNumber))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);

        [HttpPut(ApiRoutes.Invoice.DeleteInvoice)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid invoiceId) =>
            await Result.Create(invoiceId, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CleanRoomRequestCompletedCommand(invoiceId))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);
    }
}
