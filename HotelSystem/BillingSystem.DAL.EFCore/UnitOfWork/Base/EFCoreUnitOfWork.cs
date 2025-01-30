using BillingSystem.DAL.EFCore.Database;
using BillingSystem.DAL.EFCore.Repositories.Base;
using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using BillingSystem.Domain.Entities.BillingItem;
using BillingSystem.Domain.Entities.Invoice;

namespace BillingSystem.DAL.EFCore.UnitOfWork.Base;

public class EFCoreUnitOfWork : IEFCoreUnitOfWork
{
    protected readonly ApplicationDbContext _dbContext;

    public EFCoreUnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;

        BillingItemRepository = new EFCoreEntityRepository<BillingItem>(_dbContext);
        InvoiceRepository = new EFCoreEntityRepository<Invoice>(_dbContext);
    }

    public IEntityRepository<BillingItem> BillingItemRepository { get; }
    public IEntityRepository<Invoice> InvoiceRepository { get; }

    public async Task Commit()
    {
        await _dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        _dbContext.Dispose();
    }
}