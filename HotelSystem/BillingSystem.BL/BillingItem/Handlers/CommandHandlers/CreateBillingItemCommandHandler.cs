using AutoMapper;
using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class CreateBillingItemCommandHandler : CommandHandler<CreateBillingItemCommand, BillingItemDetailModel>, IRequestHandler<CreateBillingItemCommand, BillingItemDetailModel>
{
    public CreateBillingItemCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<BillingItemDetailModel> Handle(CreateBillingItemCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return null;
    }
}
