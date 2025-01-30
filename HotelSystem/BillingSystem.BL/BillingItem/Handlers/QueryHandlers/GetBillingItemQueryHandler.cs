using AutoMapper;
using BillingSystem.Application.BillingItem.Queries;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Handlers.QueryHandlers;

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
