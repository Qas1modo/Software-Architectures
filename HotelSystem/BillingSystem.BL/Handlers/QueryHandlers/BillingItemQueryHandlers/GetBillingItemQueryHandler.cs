using AutoMapper;
using BillingSystem.BL.Handlers.QueryHandlers.Base;
using BillingSystem.BL.Queries.BillingItemQueries;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Handlers.QueryHandlers.BillingItemQueryHandlers;

public class GetBillingItemQueryHandler : QueryHandler<GetBillingItemQuery, BillingItemDetailModel>, IRequestHandler<GetBillingItemQuery, BillingItemDetailModel>
{
    protected readonly IMapper _mapper;
    private readonly IUnitOfWorkProvider<IEFCoreUnitOfWork> _unitOfWorkProvider;

    public GetBillingItemQueryHandler(IMapper mapper, IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider) : base(mapper)
    {
        _mapper = mapper;
        _unitOfWorkProvider = unitOfWorkProvider;
    }

    public override async Task<BillingItemDetailModel> Handle(GetBillingItemQuery request, CancellationToken cancellationToken)
    {
        using var unitOfWork = _unitOfWorkProvider.Create();
        var result = await unitOfWork.BillingItemRepository.GetByIdAsync(request.BillingItemId);

        return _mapper.Map<BillingItemDetailModel>(result);
    }
}
