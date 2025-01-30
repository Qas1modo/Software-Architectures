using BillingSystem.Presentation.Infrastructure;
using MediatR;

namespace BillingSystem.Presentation.Controllers
{
    public class PaymentController : ApiController
    {
        public PaymentController(IMediator mediator) : base(mediator)
        {
        }
    }
}
