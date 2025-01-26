using AccessSystem.Domain.Entities;
using AccessSystem.Domain.Repositories;
using SharedKernel.Application.Core.Abstractions.Data;
using SharedKernel.Infrastructure.Repositories;

namespace AccessSystem.Infrastructure.Repositories;

public class AccessLogEntryRepository : GenericRepository<AccessLogEntry>, IAccessLogEntryRepository
{
    public AccessLogEntryRepository(IDbContext dbContext) : base(dbContext)
    {
    }
}