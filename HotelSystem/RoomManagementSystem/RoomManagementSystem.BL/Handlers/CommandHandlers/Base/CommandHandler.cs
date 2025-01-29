using AutoMapper;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;

namespace RoomManagementSystem.BL.Handlers.CommandHandlers.Base;

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
