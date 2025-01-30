using BillingSystem.DAL.EFCore.Primitives;
using BillingSystem.Presentation.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Infrastructure;

[Route("api")]
public abstract class ApiController : ControllerBase
{
    protected ApiController(IMediator mediator) => Mediator = mediator;

    protected IMediator Mediator { get; }

    protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse([error]));

    protected new IActionResult Ok(object value) => base.Ok(value);

    protected new IActionResult NotFound() => base.NotFound();
}
