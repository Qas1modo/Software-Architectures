namespace HotelServiceSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    Task Commit();
}
