using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.AccessLog.Queries;
using AccessSystem.Contracts.Models.AccessLogEntry;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Api.Controllers;

public class AccessLogController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.AccessLog.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(GetAccessLogModel getAccessLogModel) =>
        await Maybe<AccessLogGetLogQuery>
            .From(new AccessLogGetLogQuery(getAccessLogModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);
    
}