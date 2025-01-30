using AutoMapper;
using BillingSystem.Application.Handlers.Base;
using BillingSystem.Application.Invoice.Commands;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;
using MediatR;

namespace BillingSystem.Application.Invoice.Handlers.CommandHandlers;

public class DeleteInvoiceCommandHandler : CommandHandler<DeleteInvoiceCommand, bool>, IRequestHandler<DeleteInvoiceCommand, bool>
{
    public DeleteInvoiceCommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
        : base(unitOfWorkProvider, mapper) { }

    public override async Task<bool> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
    {
        using var unitOfWork = _unitOfWorkProvider.Create();
        await unitOfWork.InvoiceRepository.RemoveAsync(request.Id);
        await unitOfWork.Commit();
        return true;
    }
}
