using AccessSystem.Contracts.Models.Permission;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.Permissions.Queries.GetPermission;

public record GetPermissionQuery(GetPermissionModel GetPermissionModel) : IQuery<Maybe<List<PermissionDetailModel>>>;