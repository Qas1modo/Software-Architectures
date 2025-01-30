using BillingSystem.Presentation.Infrastructure;
using MediatR;

namespace BillingSystem.Presentation.Controllers;

public class BillingItemController : ApiController
{
    public BillingItemController(IMediator mediator) : base(mediator)
    {
    }
}
