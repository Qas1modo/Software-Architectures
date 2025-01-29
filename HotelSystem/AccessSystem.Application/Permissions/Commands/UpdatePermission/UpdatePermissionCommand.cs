using AccessSystem.Contracts.Models.Permission;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands.UpdatePermission;

public record UpdatePermissionCommand(UpdatePermissionModel UpdatePermissionModel) : ICommand<Result>;