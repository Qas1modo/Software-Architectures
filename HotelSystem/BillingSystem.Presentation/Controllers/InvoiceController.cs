using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers;

public class InvoiceController : ControllerBase
{
    private readonly IMediator _mediator;

    public InvoiceController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
