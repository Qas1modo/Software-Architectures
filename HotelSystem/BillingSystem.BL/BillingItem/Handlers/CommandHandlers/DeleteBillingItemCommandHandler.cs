using AutoMapper;
using BillingSystem.Application.BillingItem.Commands;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using MediatR;

namespace BillingSystem.Application.BillingItem.Handlers.CommandHandlers;

public class DeleteBillingItemCommandHandler : CommandHandler<DeleteBillingItemCommand, bool>, IRequestHandler<DeleteBillingItemCommand, bool>
{
    public DeleteBillingItemCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<bool> Handle(DeleteBillingItemCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = _unitOfWorkProvider.Create();
        await unitOfWork.BillingItemRepository.RemoveAsync(request.Id);
        await unitOfWork.Commit();
        return true;
    }
}
