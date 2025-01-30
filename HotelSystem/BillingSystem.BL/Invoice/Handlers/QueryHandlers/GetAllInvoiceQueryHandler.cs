using AutoMapper;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.Application.Invoice.Queries;
using BillingSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;
using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.Application.Invoice.Handlers.QueryHandlers;

public class GetAllInvoiceQueryHandler : QueryHandler<GetAllInvoiceQuery, List<InvoiceListModel>>, IRequestHandler<GetAllInvoiceQuery, List<InvoiceListModel>>
{
    private readonly IQueryObject<Domain.Entities.Invoice.Invoice> _invoiceQueryObject;

    public GetAllInvoiceQueryHandler(IMapper mapper, IQueryObject<Domain.Entities.Invoice.Invoice> invoiceQueryObject) : base(mapper)
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
