namespace RoomManagementSystem.DAL.InfraStructure.UnitOfWork.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
}

