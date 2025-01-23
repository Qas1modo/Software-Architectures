using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.DAL.EFCore.Repositories.Base;
using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;

namespace BillingSystem.DAL.EFCore.UnitOfWork.Base;

public class EFCoreUnitOfWork : IEFCoreUnitOfWork
{
    protected readonly ApplicationDbContext _dbContext;

    public EFCoreUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        BillingItemRepository = new EFCoreEntityRepository<BillingItemEntity>(_dbContext);
        InvoiceRepository = new EFCoreEntityRepository<InvoiceEntity>(_dbContext);
    }

    public IEntityRepository<BillingItemEntity> BillingItemRepository { get; }
    public IEntityRepository<InvoiceEntity> InvoiceRepository { get; }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}