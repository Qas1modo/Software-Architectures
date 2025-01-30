using RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces.Base;

namespace RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkProvider<TUnitOfWork> where TUnitOfWork : IUnitOfWork
    {
        public TUnitOfWork Create();

    }

}