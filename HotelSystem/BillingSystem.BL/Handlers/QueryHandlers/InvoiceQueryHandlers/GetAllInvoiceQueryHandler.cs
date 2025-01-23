using AutoMapper;
using BillingSystem.BL.Handlers.QueryHandlers.Base;
using BillingSystem.BL.Queries.InvoiceQueries;
using BillingSystem.DAL.EFCore.Entities;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.BL.Handlers.QueryHandlers.InvoiceQueryHandlers;

public class GetAllInvoiceQueryHandler : QueryHandler<GetAllInvoiceQuery, List<InvoiceListModel>>, IRequestHandler<GetAllInvoiceQuery, List<InvoiceListModel>>
{
    private readonly IQueryObject<InvoiceEntity> _invoiceQueryObject;

    public GetAllInvoiceQueryHandler(IMapper mapper, IQueryObject<InvoiceEntity> invoiceQueryObject) : base(mapper)
    {
        _invoiceQueryObject = invoiceQueryObject;
    }

    public override async Task<List<InvoiceListModel>> Handle(GetAllInvoiceQuery request, CancellationToken cancellationToken)
    {
        if (request.Page > 0 && request.PageSize > 0)
            _invoiceQueryObject.Page(request.Page, request.PageSize);

        var invoices = await _invoiceQueryObject.ExecuteAsync();
        return _mapper.Map<ICollection<InvoiceListModel>>(invoices).ToList();
    }
}
