using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.Permissions.Commands;
using AccessSystem.Application.Permissions.Queries;
using AccessSystem.Contracts.Models.Permission;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Api.Controllers;

public class PermissionController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.Permission.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(GetPermissionModel getPermissionModel) =>
        await Maybe<PermissionGetPermissionQuery>
            .From(new PermissionGetPermissionQuery(getPermissionModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);
    
    [HttpPost(ApiRoutes.Permission.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreatePermissionModel createPermissionModel) =>
        await Result.Create(createPermissionModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreatePermissionCommand(createPermissionModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    [HttpPatch(ApiRoutes.Permission.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdatePermissionModel updatePermissionModel) =>
        await Result.Create(updatePermissionModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new UpdatePermissionCommand(updatePermissionModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    [HttpDelete(ApiRoutes.Permission.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(DeletePermissionModel deletePermissionModel) =>
        await Result.Create(deletePermissionModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new DeletePermissionCommand(deletePermissionModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}