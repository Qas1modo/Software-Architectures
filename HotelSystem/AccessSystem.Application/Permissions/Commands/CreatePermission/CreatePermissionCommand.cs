using AccessSystem.Contracts.Models.Permission;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands.CreatePermission;

public record CreatePermissionCommand(CreatePermissionModel CreatePermissionModel) : ICommand<Result>;