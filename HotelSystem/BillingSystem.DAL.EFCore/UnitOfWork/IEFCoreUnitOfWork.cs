using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;

namespace BillingSystem.DAL.EFCore.UnitOfWork;

public interface IEFCoreUnitOfWork : IUnitOfWork
{
    public IEntityRepository<BillingItemEntity> BillingItemRepository { get; }
    public IEntityRepository<InvoiceEntity> InvoiceRepository { get; }
}
