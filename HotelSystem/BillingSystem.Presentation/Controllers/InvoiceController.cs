using BillingSystem.Presentation.Infrastructure;
using MediatR;

namespace BillingSystem.Presentation.Controllers;

public class InvoiceController : ApiController
{
    public InvoiceController(IMediator mediator) : base(mediator)
    {
    }
}
