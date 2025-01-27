
using RoomManagementSystem.Contracts.Models.RoomModels;
using RoomManagementSystem.DAL.Infrastructure.QueryObjects.Interfaces.Base;

namespace RoomManagementSystem.DAL.Infrastructure.QueryObjects.Interfaces;

public interface IGetRoomByFilter<TEntity> : IQueryObject<TEntity> where TEntity : class, new()
{
    IQueryObject<TEntity> UseFilter(RoomFilterModel roomFilter);
}
