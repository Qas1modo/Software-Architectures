using BillingSystem.DAL.EFCore.Database;

namespace BillingSystem.DAL.EFCore.UnitOfWork.Base;

public class EFCoreUnitOfWork : IEFCoreUnitOfWork
{
    protected readonly ApplicationDbContext _dbContext;

    public EFCoreUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        // _Repository = new EFCoreEntityRepository<_Entity>(_dbContext);
        // ...
    }

    // public IEntityRepository<_Entity> _Repository { get; }
    // ...

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}