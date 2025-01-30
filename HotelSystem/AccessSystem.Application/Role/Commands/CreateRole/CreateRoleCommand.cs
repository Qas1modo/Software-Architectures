using AccessSystem.Contracts.Models.Role;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Role.Commands.CreateRole;

public record CreateRoleCommand(CreateRoleModel CreateRoleModel) : ICommand<Result>;