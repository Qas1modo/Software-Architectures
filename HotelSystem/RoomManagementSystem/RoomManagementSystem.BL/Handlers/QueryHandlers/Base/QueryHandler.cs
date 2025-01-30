using AutoMapper;
using MediatR;
using RoomManagementSystem.DAL.EFCore.UnitOfWork;
using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces;

namespace RoomManagementSystem.BL.Handlers.QueryHandlers.Base;

public abstract class QueryHandler<TInputCommand, TResponse>(IUnitOfWorkProvider<IEFCoreUnitOfWork> unitOfWorkProvider, IMapper mapper)
    : IRequestHandler<TInputCommand, TResponse> where TInputCommand : IRequest<TResponse>
{
    protected readonly IUnitOfWorkProvider<IEFCoreUnitOfWork> _unitOfWorkProvider = unitOfWorkProvider;
    protected readonly IMapper _mapper = mapper;

    public abstract Task<TResponse> Handle(TInputCommand request, CancellationToken cancellationToken);
}
