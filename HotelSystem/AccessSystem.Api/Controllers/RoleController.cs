using AccessSystem.Api.Contracts;
using AccessSystem.Api.Infrastructure;
using AccessSystem.Application.Role.Commands;
using AccessSystem.Application.Role.Commands.CreateRole;
using AccessSystem.Application.Role.Commands.DeleteRole;
using AccessSystem.Application.Role.Commands.UpdateRole;
using AccessSystem.Application.Role.Queries;
using AccessSystem.Application.Role.Queries.GetRole;
using AccessSystem.Contracts.Models.Role;
using AccessSystem.Domain.Core.Errors;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Domain.Core.Primitives.Maybe;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Api.Controllers;

public sealed class RoleController(IMediator mediator) : ApiController(mediator)
{
    [HttpGet(ApiRoutes.Role.Get)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(GetRoleModel getRoleModel) =>
        await Maybe<GetRoleQuery>
            .From(new GetRoleQuery(getRoleModel))
            .Bind(query => Mediator.Send(query))
            .Match(Ok, NotFound);
    
    [HttpPost(ApiRoutes.Role.Post)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(CreateRoleModel createRoleModel) =>
        await Result.Create(createRoleModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new CreateRoleCommand(createRoleModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    [HttpPatch(ApiRoutes.Role.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(UpdateRoleModel updateRoleModel) =>
        await Result.Create(updateRoleModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new UpdateRoleCommand(updateRoleModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
    
    [HttpDelete(ApiRoutes.Role.Delete)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(DeleteRoleModel deleteRoleModel) =>
        await Result.Create(deleteRoleModel, DomainErrors.General.UnProcessableRequest)
            .Map(_ => new DeleteRoleCommand(deleteRoleModel))
            .Bind(command => Mediator.Send(command))
            .Match(Ok, BadRequest);
}