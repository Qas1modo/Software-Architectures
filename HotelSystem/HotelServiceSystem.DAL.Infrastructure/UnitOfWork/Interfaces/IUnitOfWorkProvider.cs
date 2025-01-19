using HotelServiceSystem.DAL.Infrastructure.UnitOfWork.Interfaces.Base;

namespace HotelServiceSystem.DAL.Infrastructure.UnitOfWork.Interfaces;

public interface IUnitOfWorkProvider<TUnitOfWork> where TUnitOfWork : IUnitOfWork
{
	public TUnitOfWork Create();

}
