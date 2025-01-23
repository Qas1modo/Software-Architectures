using AutoMapper;
using BillingSystem.BL.Commands.BillingItemCommands;
using BillingSystem.BL.Handlers.CommandHandlers.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using BillingSystem.Shared.Models.BillingItemModels;
using MediatR;

namespace BillingSystem.BL.Handlers.CommandHandlers.BillingItemCommandHandlers;

public class UpdateBillingItemCommandHandler : CommandHandler<UpdateBillingItemCommand, BillingItemDetailModel>, IRequestHandler<UpdateBillingItemCommand, BillingItemDetailModel>
{
    public UpdateBillingItemCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper) 
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<BillingItemDetailModel> Handle(UpdateBillingItemCommand request, CancellationToken cancellationToken)
    {
        // TODO Add logic
        return null;
    }
}
