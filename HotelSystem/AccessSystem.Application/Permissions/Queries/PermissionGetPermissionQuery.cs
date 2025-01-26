using AccessSystem.Contracts.Models.Permission;
using MediatR;
using SharedKernel.Contracts.Models.Core;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace AccessSystem.Application.Permissions.Queries;

public record PermissionGetPermissionQuery(GetPermissionModel GetPermissionModel) : IRequest<Maybe<PagedList<PermissionDetailModel>>>;