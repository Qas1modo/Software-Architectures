using AccessSystem.Contracts.Models.Permission;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands;

public record CreatePermissionCommand(CreatePermissionModel CreatePermissionModel) : IRequest<Result>;