using AccessSystem.Contracts.Models.Permission;
using AccessSystem.Contracts.Models.Role;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Permissions.Commands;

public record UpdatePermissionCommand(UpdatePermissionModel UpdatePermissionModel) : IRequest<Result>;