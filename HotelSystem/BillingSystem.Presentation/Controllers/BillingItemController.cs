using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Controllers;

public class BillingItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public BillingItemController(IMediator mediator)
    {
        _mediator = mediator;
    }
}
