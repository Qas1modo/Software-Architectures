using AccessSystem.Contracts.Models.Role;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.Role.Queries.GetRole;

public sealed record GetRoleQuery(GetRoleModel GetRoleModel) : IQuery<Maybe<PagedList<RoleResponseModel>>>;