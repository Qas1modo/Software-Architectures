using AutoMapper;
using BillingSystem.BL.Handlers.QueryHandlers.Base;
using BillingSystem.BL.Queries.InvoiceQueries;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.InvoiceModels;
using MediatR;

namespace BillingSystem.BL.Handlers.QueryHandlers.InvoiceQueryHandlers;

internal class GetInvoiceQueryHandler : QueryHandler<GetInvoiceQuery, InvoiceDetailModel>, IRequestHandler<GetInvoiceQuery, InvoiceDetailModel>
{
    protected readonly IMapper _mapper;
    private readonly IUnitOfWorkProvider<IEFCoreUnitOfWork> _unitOfWorkProvider;

    public GetInvoiceQueryHandler(IMapper mapper, IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider) : base(mapper)
    {
        _mapper = mapper;
        _unitOfWorkProvider = unitOfWorkProvider;
    }

    public override async Task<InvoiceDetailModel> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = _unitOfWorkProvider.Create();
        var result = await unitOfWork.InvoiceRepository.GetByIdAsync(request.InvoiceId);

        return _mapper.Map<InvoiceDetailModel>(result);
    }
}
