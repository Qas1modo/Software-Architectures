using AutoMapper;
using BillingSystem.Application.Invoice.Queries;
using BillingSystem.Domain.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.Invoice;
using SharedKernel.Application.Core.Abstractions.Messaging;
using SharedKernel.Domain.Core.Primitives.Maybe;

namespace BillingSystem.Application.Invoice.Handlers.QueryHandlers;

internal class GetInvoiceQueryHandler(IUnitOfWorkProvider<IUnitOfWork> unitOfWorkProvider, IMapper mapper)
    : IQueryHandler<GetInvoiceQuery, Maybe<InvoiceDetailModel>>
{
    public override async Task<Maybe<InvoiceDetailModel>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = unitOfWorkProvider.Create();
        var result = await unitOfWork.InvoiceRepository.GetByIdAsync(request.InvoiceId);

        return mapper.Map<InvoiceDetailModel>(result);
    }
}
