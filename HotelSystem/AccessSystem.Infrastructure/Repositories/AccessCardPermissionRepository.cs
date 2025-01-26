using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

internal class AccessCardPermissionRepository : GenericRepository<AccessCardPermission>, IAccessCardPermissionRepository
{
    public AccessCardPermissionRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}