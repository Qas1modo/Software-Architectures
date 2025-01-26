using AccessSystem.Contracts.Models.Role;
using MediatR;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.Role.Queries;

public sealed record RoleGetRoleQuery(GetRoleModel GetRoleModel) : IRequest<Maybe<PagedList<RoleResponseModel>>>;