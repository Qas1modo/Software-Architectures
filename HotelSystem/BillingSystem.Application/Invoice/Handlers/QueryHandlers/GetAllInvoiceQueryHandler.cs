using AutoMapper;
using BillingSystem.Application.Invoice.Queries;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.Invoice;
using Microsoft.EntityFrameworkCore;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.Invoice.Handlers.QueryHandlers;

public class GetAllInvoiceQueryHandler (IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider, IMapper mapper)
    : IQueryHandler<GetAllInvoiceQuery, Maybe<List<InvoiceListModel>>>
{
    public async Task<Maybe<List<InvoiceListModel>>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        var invoiceQuery = unitOfWork.InvoiceRepository.GetQuery();

        if (request.Page > 0 && request.PageSize > 0)
            invoiceQuery = invoiceQuery.Skip(request.Page * request.PageSize);

        var invoices = await invoiceQuery.ToListAsync();
        return mapper.Map<ICollection<InvoiceListModel>>(invoices).ToList();
    }
}
