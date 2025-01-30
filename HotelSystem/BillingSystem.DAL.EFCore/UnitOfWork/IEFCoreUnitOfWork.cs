using BillingSystem.DAL.Infrastructure.Repositories.Interfaces.Base;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;
using BillingSystem.Domain.Entities.BillingItem;
using BillingSystem.Domain.Entities.Invoice;

namespace BillingSystem.DAL.EFCore.UnitOfWork;

public interface IEFCoreUnitOfWork : IUnitOfWork
{
    public IEntityRepository<BillingItem> BillingItemRepository { get; }
    public IEntityRepository<Invoice> InvoiceRepository { get; }
}
