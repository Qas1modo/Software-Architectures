using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

public class AccessCardRepository : GenericRepository<AccessCard>, IAccessCardRepository
{
    public AccessCardRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}