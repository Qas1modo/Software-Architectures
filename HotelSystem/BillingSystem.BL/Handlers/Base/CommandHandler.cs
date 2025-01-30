using AutoMapper;
using BillingSystem.DAL.EFCore.UnitOfWork;
using BillingSystem.DAL.Infrastructure.UnitOfWork.Interfaces;

namespace BillingSystem.Application.Handlers.Base;

public abstract class CommandHandler<TInputCommand, TReturnModel>
{
    protected readonly IUnitOfWorkProvider<IEFCoreUnitOfWork> _unitOfWorkProvider;
    protected readonly IMapper _mapper;

    public CommandHandler(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
    {
        _unitOfWorkProvider = unitOfWorkProvider;
        _mapper = mapper;
    }

    public abstract Task<TReturnModel> Handle(TInputCommand request, CancellationToken cancellationToken);
}
