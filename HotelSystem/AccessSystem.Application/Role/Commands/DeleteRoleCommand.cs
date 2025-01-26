using AccessSystem.Contracts.Models.Role;
using MediatR;
using SharedKernel.Domain.Core.Primitives.Result;

namespace AccessSystem.Application.Role.Commands;

public record DeleteRoleCommand(DeleteRoleModel DeleteRoleModel) : IRequest<Result>;